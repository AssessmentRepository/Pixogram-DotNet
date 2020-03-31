using System;
using System.Collections.Generic;
using System.Text;

namespace Pixogram.Tests.Exceptions
{
 public class UserNotFoundException :Exception
    {
        public string message = "User Not Found";

        public UserNotFoundException()
        {

        }
        public UserNotFoundException(string messages)
        {
            message = messages;
        }
    }
}
