using System;
using System.IO; // allows program to use the StreamReader feature

class Program {
  public static void Main (string[] args) {
    var get_database = new StreamReader("database.morse"); // gets the contents of database.morse

    var database = get_database.ReadToEnd(); // saves contents of file to a variable

    string[] db_words = database.Split(" "); // splits the file content into an array of individual strings; used in the for loop to trigger the corresponding add/shoe actions

    bool add = false;

    // The boolean variable is used by the for loop to detect the add keyword in the db_words array

    int add_index = 0; // add_index is used to direct the program to the database.morse parameter if statements 

    // add_index, variable, and key_value must be initialized outside for loop to prevent errors

    string variable = ""; // used in the for loop

    string[] key_value = {" ", " "}; // initialized with two empty strings as placeholders for the key and value
    
    for (int i = 0; i < db_words.Length; i++) {
      
      if (db_words[i] == "•--••-••") {
        add = true;
        add_index = i;
        continue;
      }

      if (db_words[i] == "•••••••---•--") {
        
        Console.Write("\n\nKey: ");
        Console.Write(key_value[0]);
        
        Console.Write("\nValue: ");
        Console.Write(key_value[1]);

        // This Console.Write setup with newline characters makes the output clean and organized
        
        continue;
      }

      if (add == true && i == add_index + 1) {
        variable = db_words[i]; // targets the key parameter of add keyword
        
        continue;
      }

      if (add == true && i == add_index + 2) {
        string value = db_words[i]; // targets the value parameter of add keyword

        key_value[0] = variable;

        key_value[1] = value;
        
        add = false; // to avoid potential unexpected outcomes, it id best for add to be reset to false (same applies with show)
        
        continue;
      }
    }
  }
}
