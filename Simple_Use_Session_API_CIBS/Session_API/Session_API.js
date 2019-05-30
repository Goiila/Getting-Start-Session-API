//Begin use when login for Post data to Web api
function _convert(obj) {
    return {
        ID: obj.ID,
        NAME: obj.NAME,
        TEAM: obj.TEAM,
        STATUS: obj.STATUS,
        //LAST_CHANGED: SetFormatDate2Input(parseInt(obj.LAST_CHANGED.substr(6))),
        _LAST_CHANGED: SetFormatDate2Input(parseInt(obj.LAST_CHANGED.substr(6))),
        EMPLOYEE_ID: obj.EMPLOYEE_ID,
        EMPLOYEE_CODE: obj.EMPLOYEE_CODE,
        DEPARTMENT: obj.DEPARTMENT,
        TEAM_LEADER: obj.TEAM_LEADER,
        Email: obj.Email,
        Request_Date: obj.Request_Date,
        HavePicture: obj.HavePicture,
        //TimeStamp: SetFormatDate2Input(parseInt(obj.TimeStamp.substr(6)),1),
        _TimeStamp: SetFormatDate2Input(parseInt(obj.TimeStamp.substr(6)), 1),
        LogginNow: obj.LogginNow,
    };
}

function Post_Session(obj) {
    var _user_session = JSON.stringify(_convert(obj)).toString();
    AjaxCallSessionAPI(_user_session, 1);
}
//End use when login for Post data to Web api

//Begin State Logout
//Convert obj
function _convertdata4Logout(emp_id) {
    return {
        EMPLOYEE_ID: emp_id,
        LogginNow: false,
    }
}
//call api with ajax
function _logoutwithAPI(emp_id) {
    //alert(emp_id);
    var _user_logout = JSON.stringify(_convertdata4Logout(emp_id)).toString();
    AjaxCallSessionAPI(_user_logout, 0);
}
//End State Logout

//Ajax call api
function AjaxCallSessionAPI(_user, state) {
    $.ajax({
        CrossDomain: true,
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Access-Control-Allow-Methods': 'POST',
            'Access-Control-Allow-Headers': 'Origin, X-Requested-With, Content-Type, Accept'
        }, type: 'POST', contentType: 'application/json; charset=utf-8',
        url: 'http://localhost:8085/api/session/post',
        data: { _u: btoa(_user) },
        dataType: 'jsonp',
        jsonpCallback: (state == 1 ? _gotoIndex() : window.location.href = 'http://localhost:85/login/logout'), //Go to index code on front-end
        success: function (data) { }
    });
}

//for logout with other site
function _href_logoutCrossController(emp_code) {
    //////for call from client site to port 85 for logoutW
    //window.open('/home/logout?e=' + emp_code);
    //window.open('http://localhost:85/login/logout?e=' + emp_code, '_self');

    //var urls = new Array();
    ////for call main site
    //urls.push('http://localhost:85/login/logout?e=' + btoa(emp_code));
    ////call your site
    //urls.push('/home/logout?e=' + emp_code);
    ////Loop for call window.open(url)
    //for (var i = 0; i < urls.length; i++) {
    //    var link = document.createElement('a');
    //    //link.setAttribute('download', null);
    //    link.style.display = 'none';
    //    document.body.appendChild(link);
    //    link.setAttribute('href', urls[i]);
    //    link.click();
    //    document.body.removeChild(link);
    //}
}