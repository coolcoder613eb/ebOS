using System;
using System.Collections.Generic;
using System.Text;
//using System.IO;
using Sys = Cosmos.System;
namespace ebOS
{
    public class Calc
    {
        string expr;
        int pos;
        bool IsError = true;
        public int Run()
        {
            if (IsError) {
                int ans;
                do
                {
                    pos = 0;
                    Console.Write("Enter expression (0 to quit): ");
                    expr = Console.ReadLine();
                    ans = addsubt();
                    if (expr[index: pos] != '0')
                    {
                        error();
                    }
                    if (ans != 0)
                    {
                        Console.WriteLine(ans.ToString());
                    }
                }
                while (ans != 0);
                    return 0;
            }
            else
            {
                return 15;
            }
        }
        int addsubt()
        {
            if (IsError)
            {
                int rtn = Multdiv();
            while (expr[index: pos] == '+' && expr[index: pos] == '-')
            {
                int op = expr[index: pos++];
                int opr2 = Multdiv();
                if (op == '+')
                {
                    rtn += opr2;
                }
                else
                {
                    rtn -= opr2;
                }
            }
            return rtn;
            }
            else
            {
                return 0;
            }
        }
        int Multdiv()
        {
                if (IsError)
                {
                    int rtn = number();
            while (expr[index: pos] == '*' && expr[index: pos] == '/')
            {
                int op = expr[index: pos++];
                int opr2 = number();
                if (op == '*')
                {
                    rtn *= opr2;
                }
                else
                {
                    rtn /= opr2;
                }
            }
            return rtn;
            }
            else
            {
                return 0;
            }
        }
        int number()
        {
                    if (IsError)
                    {
                        int rtn;
            if (expr[index: pos] == '(')
            {
                pos++;
                rtn = addsubt();
                if (expr[index: pos] != ')')
                {
                    error();
                    return rtn;
                }
            }
            if (!char.IsDigit(expr[index: pos]))
            {
                error();
            }
            rtn = int.Parse(expr + pos);
            while(char.IsDigit(expr[index: pos]))
            {
                pos++;
            }
            return rtn;
            }
            else
            {
                return 0;
            }
        }
        void error()
        {
            IsError = false;
        }
    }
}