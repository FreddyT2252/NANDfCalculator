using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    public class Calculator
    {
        protected Expr operand1;
        protected Expr operand2;
        protected string operatorSign;
        protected bool isOperation;
        protected double ans;
        protected Queue<double> memory;

        // default constructor
        public Calculator()
        {
            operand1 = new TerminalExpr(0);
            operand2 = new TerminalExpr(0);
            ans = 0.0;
            isOperation = false;
            memory = new Queue<double>();
        }
        // menghapus semua yang dilayar
        public void Reset()
        {
            operand1 = new TerminalExpr(0);
            operand2 = new TerminalExpr(0);
            isOperation = false;
            memory = new Queue<double>();
        }
        //mengubah string yang diterima menjadi double dan disimpan ke operand
        public void SetOperand1(string number)
        {
            try
            {
                double temp = double.Parse(number);
                operand1 = new TerminalExpr(temp);
            }
            catch (Exception)
            {
                throw new InvalidOperation("Operasi tidak valid.");
            }
        }
        public void SetOperand2(string number)
        {
            double temp = double.Parse(number);
            operand2 = new TerminalExpr(temp);
        }
        public void SetAns(string number)
        {
            ans = double.Parse(number);
        }
        public void SignOperator(string sign)
        {
            operatorSign = sign;
        }
        public double GetAns()
        {
            return ans;
        }
        public string GetSignOperator()
        {
            return operatorSign;
        }
        public void SetStateOperation(bool state)
        {
            isOperation = state;
        }
        public bool GetStateOperation()
        {
            return isOperation;
        }
        // memasukkan angka ke dalam memori
        public void SetMemory(string nums)
        {
            memory.Enqueue(double.Parse(nums));
        }
        public bool isMemEmpty()
        {
            return memory.Count == 0;
        }
        public double calculate()
        {
            Expr temp = new TerminalExpr(0);
            switch(operatorSign)
            {
                case "+":
                    temp = new AddExpr(operand1, operand2);
                    break;
                case "-":
                    temp = new SubstractExpr(operand1, operand2);
                    break;
                case "*":
                    temp = new MultiplyExpr(operand1, operand2);
                    break;
                case "/":
                    temp = new DivideExpr(operand1, operand2);
                    break;
            }
            return temp.solve();
        }
    }
}
