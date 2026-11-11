// The grammar: one record per rule
internal abstract record Expr;
internal record Number(int Value) : Expr;
internal record Add(Expr Left, Expr Right) : Expr;
internal record Multiply(Expr Left, Expr Right) : Expr;
