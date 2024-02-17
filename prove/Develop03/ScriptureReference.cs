using System;

class ScriptureReference
{
    //this class has a public property the gets or sets the value of the 'referenceString' instance variable.
    public string ReferenceString { get; private set;}
    //constructor takes a string argument.
    public ScriptureReference(String referenceString)
    {
        ReferenceString = referenceString;

    }
//The ToString method returns a string that represents the current object. 
//In this case,the ToString method returns the value of the ReferenceString property.
    public override string ToString()
    {
        return ReferenceString;
    }




}