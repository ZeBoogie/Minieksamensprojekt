window.ParseQueryString = function () {
    //Get the current location in the address bar
    var url = window.location.href,
        parameterSet = [],
        //Get everything to the right of the '?'
        parameterString = url.split('?')[1];

    //Do we have anything to work with?
    if (parameterString) {
        //Lets get all individual parameter in the parameter string
        var parameterParts = parameterString.split('&');

        for (var i = 0, e; e = parameterParts[i++];) {
            //Get the parameter key and the value
            var parameter = e.split('=');

            //Push it into the array
            parameterSet.push({
                'key': parameter[0],
                'value': parameter[1]
            });
        }
    }

    //Give me my prettyfied query string array plz!
    return parameterSet;
}
