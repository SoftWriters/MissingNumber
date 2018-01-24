using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MissingNumber
{
    /// <summary>
    /// Simple ViewModel to control basic flow of application, not really a true view model but similiar in responsibility 
    /// </summary>
    public class MainViewModel
    {
        private FileParser _parser = new FileParser();

        /// <summary>
        /// Results that correspond to the input. These are the missing Numbers
        /// </summary>
        public ObservableCollection<int> Results { get; private set; } = new ObservableCollection<int>();

        /// <summary>
        /// Takes a file from the user and finds all the missing numbers
        /// </summary>
        /// <param name="fileLocation">Location of the file to use</param>
        public void ReadFile(string fileLocation)
        {
            Results.Clear();
            IList<NumberLine> numLines = _parser.ParseFile(fileLocation);
            foreach (NumberLine numLine in numLines)
            {
                Results.Add(numLine.MissingNumber);
            }
        }
    }
}
