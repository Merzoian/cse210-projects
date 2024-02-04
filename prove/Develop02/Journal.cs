using System;

class Journal
{
public List<Entry> entries;
    public Journal()
    {
            //Add the class journal and to make list of the follwing:
            //1. addEntry and Display entries 

    entries = new List<Entry>();
    }

    public void AddEntry(Entry entry)  
        {
        entries.Add(entry);
        }
    public void DisplayEntries()
    {
    foreach (var entry in entries)
        {
        Console.WriteLine($"Date: {entry.Date}\nPrompt:{entry.Prompt}\nResponse:{entry.Response}\n");
        }
    }  

             //2.save to file, load form file.
 public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))// create a stream form a file, if exist the writer will override its content,
                                                                // if not this constructor creates new file.
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved successfully!");
    }

//Now  we need a method that can load from a text file.

public void LoadFormFile(string filename)
{
//clear existing entries before loading form file:
entries.Clear();
try// it handle exceptions that may accur while exeuting the code
{
    using (StreamReader reader = new StreamReader(filename))
    {
        while (!reader.EndOfStream)// loop will continue  until end of stream is reached.
        {
            string[] entryData = reader.ReadLine().Split('|');// reads  one line at time and split by '|' symbol getting the indiviual pieces of date for each entry.
                    Entry entry = new Entry(entryData[1], entryData[2], entryData[0]);
                    entries.Add(entry);
        }
    }
    //the output of loading done 
    Console.WriteLine("Journal  loaded successfully!");
}
catch (FileNotFoundException)
{
    Console.WriteLine("Unable to open file. Create a new  journal or check your path.");
}
}



}