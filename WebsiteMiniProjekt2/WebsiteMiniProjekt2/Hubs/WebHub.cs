using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections;
using System.Diagnostics;
using System.Xml.Linq;
using Newtonsoft.Json;
using Microsoft.Data.Sqlite;

namespace WebsiteMiniProjekt2.Hubs
{
    public class WebHub : Hub
    {
        static List<int> codesInUse = new List<int>();
        static List<string> namesInUse = new List<string>();
        //Dictionary with all the players' names, and what they've answered
        public static Dictionary<string, List<string>> playersAndAnswers = new Dictionary<string, List<string>>();
        //List of strings with players names, matrix with Answers for each person

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public void removeCode(int code)
        {
            if(codesInUse.Contains(code))
            {
                codesInUse.Remove(code);
                svend();
            }
        }


        public async Task AttemptedLogin(string code)
        {
            Trace.WriteLine("attempted login method with " + code);
            if(!codesInUse.Contains(42))
            {
                codesInUse.Add(42);
            }
            //return wrong code, if input isn't a number, or of it isn't in our list
            if (!int.TryParse(code, out int codeint) || !codesInUse.Contains(codeint))
            {
                Trace.WriteLine("wrong code");

                await Clients.Caller.SendAsync("wrongStatement", "code");
                return;
            }

            await Clients.Caller.SendAsync("goToPage", "Namepage");

			//Client (webpage), asks if a user has entered a valid code
			//if this is the case, then send back a command to the client
			//telling them to switch side
		}

		public async Task AttamptedUsername(string userName) 
            //this method hasn't been tested
        {
            Trace.WriteLine("attempted chossing following username " + userName);
            //return wrong code, if input isn't a number, or of it isn't in our list
            if (namesInUse.Contains(userName))
            {
                Trace.WriteLine("username is not available");
				await Clients.Caller.SendAsync("wrongStatement", "username");
                return;
            }
            namesInUse.Add(userName);
			Trace.WriteLine("username available");
			foreach (string name in namesInUse)
			{
				Trace.WriteLine(name);
			}
			//if username is valid, add it to the dictionary as a key;
			playersAndAnswers.Add(userName, new List<string>());
            await Clients.Caller.SendAsync("goToPage", "Waitingpage");


			//Client (webpage), asks if a user has entered a valid code
			//if this is the case, then send back a command to the client
			//telling them to switch side
		}
		public async Task nextQuestion() //sends webpages to multiple choice
        {
			foreach (KeyValuePair<string, List<string>> ele2 in playersAndAnswers)
			{
				Trace.WriteLine("----adding noAnswer to all players-----");
				List<string> answers = ele2.Value; //save the answers of the quizzer in list
				answers.Add("noAnswer"); //modify the last element of the list, as it earlier has been set to "noAnswer"
				playersAndAnswers[ele2.Key] = answers;
				Trace.WriteLine("added " + ele2.Value + " to player " + ele2.Value);
			}
			await Clients.All.SendAsync("nextQuestion");
            Trace.WriteLine("sending clients to next question");
        }

        public async Task giveMeCode()
        {
            Random rnd = new Random();
            bool foundNewCode = false;
            int code = 0;
            int i = 0;
            while (!foundNewCode)
            {
                i++;
                foundNewCode = true;
                code = rnd.Next(1000, 10000);  // creates a number between 1 and 12
                foreach (int usedCode in codesInUse)
                {
                    Trace.WriteLine($"comparing usedcode {usedCode} and {code}");

                    if (usedCode == code)
                    {
                        foundNewCode = false;
                    }
                }
                Trace.WriteLine($"foundnewCode is {foundNewCode}, this time is {i}");

            }
            Trace.WriteLine($"current chosen code is {code}");
            Trace.WriteLine($"codesinuse bfore are{string.Join(",", codesInUse)}");

            codesInUse.Add(code);
            Trace.WriteLine($"codesinuse after are{string.Join(",", codesInUse)}");


            await Clients.Caller.SendAsync("useThisCode", code);
        }
        public void svend()
        {
            Database DatabaseObj = new Database();
            string query = "INSERT INTO Personer (Navn) VALUES (@bob)";
            SqliteCommand myCommand = new SqliteCommand(query, DatabaseObj.myConnecntion);

            if (DatabaseObj.myConnecntion.State != System.Data.ConnectionState.Open)
            {
                DatabaseObj.myConnecntion.Open();
            }
            myCommand.Parameters.AddWithValue("@bob", "cage");
            myCommand.ExecuteNonQuery();
            if (DatabaseObj.myConnecntion.State != System.Data.ConnectionState.Closed)
            {
                DatabaseObj.myConnecntion.Close();
            }
        }

        public Task saveDataToDatabase(List<string> titlesOfQuestions, List<string> questions, List<List<string>> answerOptions,
            DateTime sessionStart, DateTime sessionEnd, int PowerPointID)
        {
            /*Spoergsmaalsdata data = new Spoergsmaalsdata();
            string mellemmand = File.ReadAllText("C:\\ProgramData\\PowerPointQuiz\\" + valgt + ".json");
            data = JsonConvert.DeserializeObject<Spoergsmaalsdata>(mellemmand);
            */
            
            Database DatabaseObj = new Database();
            string query = "INSERT INTO Personer (Navn) VALUES (@bob)";
            SqliteCommand myCommand = new SqliteCommand(query, DatabaseObj.myConnecntion);
           
            if (DatabaseObj.myConnecntion.State != System.Data.ConnectionState.Open) 
            {
                DatabaseObj.myConnecntion.Open();
            }
            myCommand.Parameters.AddWithValue("@bob", "cage");
            myCommand.ExecuteNonQuery();
            if (DatabaseObj.myConnecntion.State != System.Data.ConnectionState.Closed)
            {
                DatabaseObj.myConnecntion.Close();
            }


            //PowerPointID is a number used so that you can only acces data that belongs to the powerpoint.
            //takes all the important data as input (i think, you can add more if needed)
            //you can acces all the players' answers and names in the dictionary, as seen in code below.
            foreach (KeyValuePair<string, List<string>> ele2 in playersAndAnswers)
			{
				Trace.WriteLine("this is the dictionary");
				Trace.WriteLine("dictionary key is users name and is " + ele2.Key + " and the amount of answers from that player is " + ele2.Value.Count);
			};


			//save all the data above into database
			return Task.CompletedTask;
		}

		public Task submitAnswer(string nameOfQuizzer, string quizID, string answer)
        {
            foreach (KeyValuePair<string, List<string>> ele2 in playersAndAnswers)
            {
				Trace.WriteLine("---printing dictionary - at submitAnswer---");
				Trace.WriteLine("dictionary key is " + ele2.Key + " and it countains following amount of answers: " + ele2.Value.Count);
			}
            try
            {
				List<string> answers = playersAndAnswers[nameOfQuizzer]; //save the answers of the quizzer in list
                answers[answers.Count-1] = answer; //modify the last element of the list, as it earlier has been set to "noAnswer"
				playersAndAnswers[nameOfQuizzer] = answers;

			}
            catch(Exception ex)
            {
                Trace.WriteLine("****couldn't add answers to " + nameOfQuizzer + ". Perhaps he didn't exist. ans was" + answer + "****");
            }

            //print dictionary second time
            foreach (KeyValuePair<string, List<string>> ele2 in playersAndAnswers)
            {
                Trace.WriteLine("----If no exception was thrown---");
                Trace.WriteLine("dictionary key is " + ele2.Key + " and it contains following answers: " + string.Join(", ", ele2.Value));
            }

            return Task.CompletedTask;

            //TODO save answer in dictionary.
		}



		public static void saveAnswersToDatabase()
        {
            //TODO: A method that saves all the relevant data to a database
            //There should be created variables for session time start etc.
            //F.eks. dictionary of what people has answered sould be saved
        }
        public Task PrintString(string String) //be aware that input from
                                               //html forms, will most likely be a string, you have earlier in your
                                               //life spent more than an hour being confused why there was an
                                               //error on your server, due to this... 13-12-2022
        {
            Trace.WriteLine(" --------------" + String + "--------------");
            return Task.CompletedTask;
        }

        public Task PrintBool(bool bollean)
        {
            Trace.WriteLine(bollean);
            return Task.CompletedTask;
        }
    }
}
