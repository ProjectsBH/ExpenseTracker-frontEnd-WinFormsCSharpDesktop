﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerCallAPIWinForms.ViewModel.Utils.FinalResults
{
    public class ServicesResultsDRY
    {
        public static ServicesResultsDto GetDefault()
        {
            return getResult(true, ResultsTypes.None, "");
        }
        public static ServicesResultsDto GetSuccess(string message = null)
        {
            return getResult(true, ResultsTypes.Done, message);
            //var tuple = GetCodeMessage(ResultsTypes.Done);
            //return new ServicesResults().Success(true).ResponseCode(tuple.Item1).Message(GetMerge(tuple.Item2,message)).Results();
        }
        public static ServicesResultsDto GetSuccessWithId(object id, string message = null)
        {
            return GetResultWithId(true, id, ResultsTypes.Done, message);
        }
        public static ServicesResultsDto GetError(ResultsTypes resultType = ResultsTypes.None, string message = null)
        {
            return getResult(false, resultType, message);
        }
        public static ServicesResultsDto GetIncorrectInput(string message = null)
        {
            return getResult(false, ResultsTypes.Incorrect_Input, message);
        }
        public static ServicesResultsDto GetException()
        {
            return getResult(false, ResultsTypes.Exception);
        }
        public static ServicesResultsDto GetException(Exception ex)
        {
            GetException();
            throw new ArgumentException(ex.ToString());
        }
        public static ServicesResultsDto GetResult(bool success, ResultsTypes resultType, string message = null)
        {
            return getResult(success, resultType, message);
        }
        private static ServicesResultsDto getResult(bool success, ResultsTypes resultType, string message = null)
        {
            var tuple = GetCodeMessage(resultType);
            return new ServicesResultsDtoBuilder().Success(success).ResponseCode(tuple.Item1).Message(GetMerge(tuple.Item2, message)).ResultType(resultType).Results();
        }
        private static ServicesResultsDto GetResultWithId(bool success, object id, ResultsTypes resultType, string message = null)
        {
            var tuple = GetCodeMessage(resultType);
            return new ServicesResultsDtoBuilder().Success(success).ResponseCode(tuple.Item1).Message(GetMerge(tuple.Item2, message)).ResultType(resultType).Id(id).Results();
        }
        private static string GetMessage(ResultsTypes resultType)
        {
            return ResultsCodes.GetMessage(resultType);
        }
        private static string GetMessage(ResultsTypes resultType, string message)
        {
            return ResultsCodes.GetMessage(resultType) + " :\n" + message;
        }
        private static string GetMerge(string message, string message2)
        {
            
            if (string.IsNullOrWhiteSpace(message2))
                return message;
            return message2;
            //return string.Concat(message + " :\n" + message2);
        }
        private static Tuple<string, string> GetCodeMessage(ResultsTypes resultType)
        {
            return ResultsCodes.GetCodeMessage(resultType);
        }

    }
}
