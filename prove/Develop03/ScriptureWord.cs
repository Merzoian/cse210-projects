using System;
using System.Collections.Generic;
using System.Linq;
//this class is to represent a single word from a scripture ,
// along with wheather of not the word is currently hidden.
//
//startiing with identify the class
public class ScriptureWord
{
    //here we will have properties to store the word itself and whether its hidden along
    //with methods to initialize a word and to hide it.
    public string Word { get; private set; }
    public bool Hidden { get; private set; }

    public ScriptureWord(string word)
    {
        // calling the initializer method from the constructor
        Word = word;
        Hidden = false;
    }
// this method called  "Hide" will set the Hidden property to true.
    public void Hide()
    {
        Hidden = true;
    }
// the class will overrides the Tostring() method to provide a string representation fo the word.
// if the word is hidden , then it will return an empty string otherwise it will return the word itself.
    public override string ToString()
    {
        return Hidden ? "______" : Word;
    }
}
