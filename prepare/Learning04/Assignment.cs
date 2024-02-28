using System;

public class Assignment{

private string _studentName;
private string _topic;

public Assignment (string studentName, String  topic )
{
_studentName = studentName;
_topic = topic;
}

public string GetStudentName()
{
    return _studentName;
}

public string GetTopic()

{
return _topic;
}

public string  GetSummary()
{

    return _studentName +"-"+ "Assigned to "+ _topic ;
}





}


