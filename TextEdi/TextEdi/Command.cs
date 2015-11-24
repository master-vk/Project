using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEdi
{
    
    public class Command
    {
        public Command ()
	    {
            args = new object[MAX_ARGS];
	    }

        public const int MAX_ARGS = 2;


        public void Memo(object[] obj)
        {
            _stack.Push(obj);
        }
        public object[] Undo()
        {
            if (_stack.Count != 0)
            {
                return _stack.Pop();
            }
            return null;
        }
        
        
     
        object[] args;
        
        Stack<object[]> _stack = new Stack<object[]>();
        
    }
}
