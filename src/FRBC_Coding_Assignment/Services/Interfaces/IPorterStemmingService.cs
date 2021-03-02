using System;
using System.Collections.Generic;
using System.Text;

namespace FRBC_Coding_Assignment.Services.Interfaces
{
    public interface IPorterStemmingService
    {
        string[] RunStemmingAlgorithm(string[] wordArray);
    }
}
