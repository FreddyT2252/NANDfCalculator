using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    // Untuk sementara masi +,-,x,bagi.
    // Entar bisa nambah modulus atau %, power atau pangkat, squareroot atau akar.
    public abstract class Expr
    {
        public Expr()
        {

        }
        public abstract double solve();
    }

    public abstract class BinaryExpr : Expr
    {
        protected Expr x;
        protected Expr y;

        public BinaryExpr(Expr x, Expr y)
        {
            this.x = x;
            this.y = y;
        }

        override
        public abstract double solve();
    }
    public abstract class UnaryExpr : Expr
    {
        protected Expr x;
        public UnaryExpr(Expr x)
        {
            this.x = x;
        }
        override
        abstract public double solve();
    }
    public class TerminalExpr : Expr
    {
        protected double x;

        public TerminalExpr(double x)
        {
            this.x = x;
        }
        override
        public double solve()
        {
            return x;
        }
    }

    public class AddExpr : BinaryExpr
    {
        public AddExpr(Expr x, Expr y) : base(x,y){ }

        override
        public double solve()
        {
            return x.solve() + y.solve();
        }
    }

    public class SubstractExpr : BinaryExpr
    {
        public SubstractExpr(Expr x, Expr y) : base(x, y) { }
        override
        public double solve()
        {
            return x.solve() - y.solve();
        }
    }

    public class DivideExpr : BinaryExpr
    {
        public DivideExpr(Expr x, Expr y) : base(x, y) { }
        override
        public double solve()
        {
            if (y.solve()==0)
            {
                throw new ZeroException("Tidak bisa membagi 0.");
            }
            else
            {
                return x.solve() / y.solve();
            }
        }
    }
    public class MultiplyExpr : BinaryExpr
    {
        public MultiplyExpr(Expr x, Expr y) : base(x,y){ }
        override
        public double solve()
        {
            return x.solve() * y.solve();
        }
    }
}
