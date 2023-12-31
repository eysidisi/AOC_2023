﻿using System.Runtime.Serialization;

namespace AOC_2023_Service.Day01
{
    [Serializable]
    public class IncorrectInputException : Exception
    {
        public IncorrectInputException()
        {
        }

        public IncorrectInputException(string? message) : base(message)
        {
        }
    }
}
