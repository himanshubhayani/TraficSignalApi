using System.Collections.Generic;
using System.Linq;
using Test.data.Models;

namespace Test.logic.Common
{
    public class OperationResult
    {
        public OperationResult() { }

        public OperationResult(bool success)
            : this(success, null)
        { }

        public OperationResult(bool success, string Message)
        {
            this.Success = success;
            this.Message = Message;
        }

        public OperationResult(bool success, int Id)
        {
            this.Success = success;
            this.Message = Message;
        }

        public OperationResult(bool success, string Message, object data)
        {
            this.Success = success;
            this.Message = Message;
            this.data = data;
        }

        public bool Success { get; private set; }
        public string Message { get; private set; }
        public int Id { get; private set; }
        public object data { get; private set; }
    }

    public class OperationResult<T, J> where T : class
    {
        public OperationResult() { }

        public OperationResult(bool success)
        {
            this.Success = success;
        }

        public OperationResult(bool success, string Message)
        {
            this.Success = success;
            this.Message.Message = Message;
        }

        public OperationResult(bool success, T model)
        {
            this.Success = success;
            this.Model = model;
        }

        public OperationResult(T model)
        {
            this.Model = model;
            this.Success = true;
        }

        public OperationResult(bool success, T model, J Model)
        {
            this.Success = success;
            this.Model = model;
            this.Model1 = Model;
        }

        public OperationResult(bool success, MessageVM Message)
        {
            this.Success = success;
            this.Message = Message;
        }

        public OperationResult(bool success, MessageVM Message, T model)
        {
            this.Model = model;
            this.Success = success;
            this.Message = Message;
        }

        public OperationResult(bool success, MessageVM Message, IEnumerable<T> stateList)
        {
            this.StateList = stateList;
            this.Success = success;
            this.Message = Message;
        }

        public bool Success { get; private set; }
        public MessageVM Message { get; private set; }
        public T Model { get; private set; }

        public J Model1 { get; private set; }
        public IEnumerable<T> StateList { get; private set; }
    }

    public class OperationResult<T> where T : class
    {
        public OperationResult() { }

        public OperationResult(bool success)
        {
            this.Success = success;
        }

        public OperationResult(bool success, string Message)
        {
            this.Success = success;
            this.Message.Message = Message;
        }

        public OperationResult(bool success, T model)
        {
            this.Success = success;
            this.Model = model;
        }

        public OperationResult(T model)
        {
            this.Model = model;
            this.Success = true;
        }

        public OperationResult(MessageVM Message, bool success)
        {
            this.Success = success;
            this.Message = Message;
        }

        public OperationResult(bool success, MessageVM Message, T model)
        {
            this.Model = model;
            this.Success = success;
            this.Message = Message;
        }

        public OperationResult(bool success, MessageVM Message, IEnumerable<T> stateList)
        {
            this.StateList = stateList;
            this.Success = success;
            this.Message = Message;
        }

        public bool Success { get; private set; }
        public MessageVM Message { get; private set; }
        public T Model { get; private set; }
        public IEnumerable<T> StateList { get; private set; }
    }
}