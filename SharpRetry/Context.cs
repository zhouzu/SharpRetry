﻿using System;

namespace SharpRetry {
    public class Context {
        public bool IsFailure => !IsSuccess;
        public bool IsSuccess { get; set; }
        public string CallName { get; set; }
        public int Calls { get; set; }
        public Exception Exception { get; set; }
        public DateTime? CallBegin { get; set; }
        public DateTime? CallEnd { get; set; }
        public TimeSpan? CallDuration {
            get {
                if(CallBegin == null || CallEnd == null) {
                    return null;
                }
                return CallEnd - CallBegin;
            }
        }

        public object Result { get; set; }

        public T CastResult<T>() {
            return (T)Result;
        }

        public Context() { }

        public Context(string callName) {
            CallName = callName;
        }
    }
}
