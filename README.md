FRBC_Coding_Assignment

Description
This program will take in a text file and perform some sanitation steps on that text file. The steps that it takes is to: remove unicode characters, remove punctuation/symbols, and remove quotes. At this point, there is a list of words that is used to compare with the stopword list. The stopword list is a text file given from the user and remove the words from the text file. It will then remove all non-alpha characters and then perform a Stemming Algorithm on each word. The words are then counted for the number of occurence and then the top n number is printed to the screen. The program will wait for the user to hit the enter key and then shut down. 

Execution Time
I tried to keep things in primitive forms until it became simpler to work with more complex objects. I felt that this is a good trade off between speed and maintainability. For example, I tried to keep things in the string form, until I needed them to be seperate words, so I formed strings into arrays. After that, it was a less complex solution to convert arrays to lists for stop word comparison and removal using Linq. Then I used Dictionaries and Key/Value pairs for counting and printing. I did this for a more readable solution, but I think that this is where speed could be affected. Something like an array might be faster for the lookup but could take a more complex solution.

Assumptions
1. I tried to follow the order from the assignment given but assumed that I should remove unneed characters first before processing. The order of the program goes: Read in file, remove unicode characters, remove symbols and punctuation, and remove quotes. This way I only had words, and then remove the stop words and continued. 
2. I assumed that I should leave in apostrophes within words but remove the use of quotes. So 'The' was trimmed to The but it's was left alone. The apostrophes are later removed due to not being non-alphabetical characters but again I tried to stay with the order of the assignment sheet, remove stopwords then remove non-alphabetical text.
3. All stopword comparisons are made with a ToLower change. This is the only time that I did this. I assumed that since all words in the file are lower case, this was the intent.
4. I did make an attempt to catch all errors and handle them gracefully. If an error is found when reading a text file then the program will assume a empty file and continue. An error should be presented to the user. I assume that the person running the program will be able to get the full path of the text files.
5. I assumed that the person running the program will be able to allow it through the anti virus software. When testing this, BitDefender and Windows did not like it and I had to allow it to be run. I was going to put this in a docker container, but I did not assume that the person running it would have docker for windows installed.
6. This assumes that the stop word list is in a certain format, like the file given in the example.

How to Run
I tried to make this a console app that can be run on a windows computer. I was able to test this successfully on a Windows 10 machine with no version of .NET installed. 

1. Download the Zip File and extract all files.
2. Place the text files in a place that you have the path to, the program will ask for the route to the files. Copies of the files are in the solution directory: FRBC_Coding_Assignment\src\FRBC_Coding_Assignment
3. Navigate to the folder that is the release version of the program and find the executable: FRBC_Coding_Assignment\src\FRBC_Coding_Assignment\bin\Release\netcoreapp3.1\win-x64\FRBC_Coding_Assignment.exe
4. Run the program and insert the path of the text file and then the stop file.

Also, this can be run within Visual Studio that has .NET Core 3.1 SDK. Open the solution within visual studio, build and then run the program. The path of the files for the text and the stopwords are still needed for this.

Results
Text1.txt
us - Number of Occurrences: 11
State - Number of Occurrences: 9
Law - Number of Occurrences: 8
Govern - Number of Occurrences: 8
peopl - Number of Occurrences: 7
right - Number of Occurrences: 7
time - Number of Occurrences: 6
among - Number of Occurrences: 5
establish - Number of Occurrences: 5
refus - Number of Occurrences: 5
power - Number of Occurrences: 4
declar - Number of Occurrences: 4
abolish - Number of Occurrences: 4
Coloni - Number of Occurrences: 4
Assent - Number of Occurrences: 4
larg - Number of Occurrences: 4
Power - Number of Occurrences: 4
becom - Number of Occurrences: 3
dissolv - Number of Occurrences: 3
connect - Number of Occurrences: 3

Text2.txt
said - Number of Occurrences: 457
Alice - Number of Occurrences: 400
littl - Number of Occurrences: 125
look - Number of Occurrences: 105
like - Number of Occurrences: 96
on - Number of Occurrences: 96
know - Number of Occurrences: 92
went - Number of Occurrences: 83
thing - Number of Occurrences: 80
thought - Number of Occurrences: 76
Queen - Number of Occurrences: 75
time - Number of Occurrences: 74
go - Number of Occurrences: 74
sai - Number of Occurrences: 71
see - Number of Occurrences: 67
get - Number of Occurrences: 66
King - Number of Occurrences: 62
think - Number of Occurrences: 60
head - Number of Occurrences: 59
Turtl - Number of Occurrences: 59

Credit
1. Stemming Algorithm: https://tartarus.org/martin/PorterStemmer/csharp4.txt
2. I have had little experience setting up dependency injection for a console app. I had to research how to get a service collection within the main entry point to set up all the classes. I used the online tutorial: https://pradeeploganathan.com/dotnet/dependency-injection-in-net-core-console-application/; github repo: https://github.com/PradeepLoganathan/Injector as examples to do this.
3. Most other information was found within documentation  