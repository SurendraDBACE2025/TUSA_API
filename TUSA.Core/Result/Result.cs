// Copyright (c) 2021 Avontix Solutions. All rights reserved.

// This source file is the confidential property and copyright of Avontix Solutions.
// Reproduction or transmission in whole or in part, in any form or
// by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written consent of the copyright owner.

namespace TUSA.Core.Result
{
    using System.Collections.Generic;

    public class BaseResult
    {
        private bool _isSuccess = false;
        private List<MessageItem> _messageList;

        public BaseResult()
        {
            _messageList = new List<MessageItem>();
        }

        public bool IsSuccess { get { return _isSuccess; } set { _isSuccess = value; } }
        public bool HasError { get { return _messageList.Count > 0 ? true : false; } }
        public bool HasNoError { get { return _messageList.Count > 0 ? true : false; } }    

        public BaseResult(bool isSuccess)
        {
            _isSuccess = isSuccess;
            _messageList = new List<MessageItem>();
        }

        public List<MessageItem> Messages
        {
            set { _messageList = value; }
            get { return _messageList; }
        }

        public bool AddMessageItem(MessageItem message)
        {
            if (message != null && !string.IsNullOrEmpty(message.Description))
            {
                _messageList.Add(message);
            }
            else { return false; }
            return true;
        }
    }
}