﻿using EventsCalendar.Interfaces.Services;
using EventsCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCalendar.BusinessLogic
{
    public class RepeatTypeService : IRepeatTypeService
    {
        /*  ----- Attributes/Fields/Properties ----- */
        private static IOperationResult _result;
        private static IRepeatTypeRepository repeatTypeContext;

        public IOperationResult Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
            }
        }


        /*  ----- Constructors ----- */
        public RepeatTypeService(IOperationResult result, IRepeatTypeRepository repeatTypeR)
        {
            _result = result;
            repeatTypeContext = repeatTypeR;
        }


        /*  ----- Public Methods ----- */
        public DBOperationResult CreateRepeatType(RepeatType repeatType)
        {
            Result.Reset();

            Result = repeatTypeContext.Create(repeatType);

            if (Result.IsError)
            {
                Result = repeatTypeContext.Result;
                Result.CustomMessage = "There was a problem creating the RepeatType";
            }

            return (DBOperationResult)Result;
        }

        public RepeatType ReadRepeatType(long repeatTypeID)
        {
            Result.Reset();

            RepeatType repeatType = repeatTypeContext.Read(repeatTypeID);

            if (repeatType == null)
            {
                Result.CustomMessage = "Could not find the requested RepeatType";
            }

            if (repeatTypeContext.Result.IsError)
            {
                Result = repeatTypeContext.Result;
                Result.CustomMessage = "There was a problem retrieving the requested RepeatType";
            }

            return repeatType;
        }

        public DBOperationResult UpdateRepeatType(RepeatType repeatType)
        {
            Result.Reset();

            Result = repeatTypeContext.Update(repeatType);

            if (Result.IsError)
            {
                Result = repeatTypeContext.Result;
                Result.CustomMessage = "There was a problem updating the requested RepeatType";
            }

            return (DBOperationResult)Result;
        }

        public DBOperationResult UpdateRepeatType(RepeatType repeatType, string[] fieldsToUpdate)
        {
            Result.Reset();

            Result = repeatTypeContext.Update(repeatType, fieldsToUpdate);

            if (Result.IsError)
            {
                Result = repeatTypeContext.Result;
                Result.CustomMessage = "There was a problem updating the requested RepeatType";
            }

            return (DBOperationResult)Result;
        }

        public DBOperationResult DeleteRepeatType(long repeatTypeID)
        {
            Result.Reset();

            Result = repeatTypeContext.Delete(repeatTypeID);

            if (Result.IsError)
            {
                Result = repeatTypeContext.Result;
                Result.CustomMessage = "There was a problem deleting the requested RepeatType";
            }

            return (DBOperationResult)Result;
        }

        public DBOperationResult DeleteRepeatType(RepeatType repeatType)
        {
            Result.Reset();

            Result = repeatTypeContext.Delete(repeatType);

            if (Result.IsError)
            {
                Result = repeatTypeContext.Result;
                Result.CustomMessage = "There was a problem deleting the requested RepeatType";
            }

            return (DBOperationResult)Result;
        }

        public List<RepeatType> GetAllRepeatTypes()
        {
            Result.Reset();

            List<RepeatType> repeatTypes = repeatTypeContext.GetAll().ToList();

            if (repeatTypes == null)
            {
                Result.CustomMessage = "Could not find the requested RepeatTypes";
            }

            if (repeatTypeContext.Result.IsError)
            {
                Result = repeatTypeContext.Result;
                Result.CustomMessage = "There was a problem retrieving the requested RepeatTypes";
            }

            return repeatTypes;
        }
    }
}
