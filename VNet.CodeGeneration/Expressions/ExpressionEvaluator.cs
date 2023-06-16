using System;
using System.Collections.Generic;
using System.Linq;
using VNet.CodeGeneration.Log;

namespace VNet.CodeGeneration.Expressions
{
    public class ExpressionEvaluator
    {
        public static double Evaluate(string expression)
        {
            var tokens = Tokenize(expression);
            var postfixTokens = ConvertToPostfix(tokens);
            return EvaluatePostfix(postfixTokens);
        }

        private static IEnumerable<string> Tokenize(string expression)
        {
            expression = expression.Replace("Math.PI", Math.PI.ToString());

            var operators = new[] { "+", "-", "*", "/", "(", ")" };
            var separators = new[] { ' ', '\t' };

            var token = string.Empty;
            var i = 0;
            while (i < expression.Length)
            {
                var c = expression[i];

                if (operators.Contains(c.ToString()) || separators.Contains(c))
                {
                    if (!string.IsNullOrEmpty(token))
                    {
                        yield return token;
                        token = string.Empty;
                    }

                    if (!separators.Contains(c))
                    {
                        yield return c.ToString();
                    }

                    i++;
                }
                else if (char.IsDigit(c))
                {
                    var number = string.Empty;
                    var hasDecimalPoint = false;

                    while (i < expression.Length)
                    {
                        var currentChar = expression[i];

                        if (char.IsDigit(currentChar))
                        {
                            number += currentChar;
                            i++;
                        }
                        else if (currentChar == '.' && !hasDecimalPoint)
                        {
                            number += currentChar;
                            hasDecimalPoint = true;
                            i++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    yield return number;
                }
                else if (c == '-' && i < expression.Length - 1 && (char.IsDigit(expression[i + 1]) || expression[i + 1] == '.'))
                {
                    var number = "-";
                    i++;
                    var hasDecimalPoint = false;

                    while (i < expression.Length)
                    {
                        var currentChar = expression[i];

                        if (char.IsDigit(currentChar))
                        {
                            number += currentChar;
                            i++;
                        }
                        else if (currentChar == '.' && !hasDecimalPoint)
                        {
                            number += currentChar;
                            hasDecimalPoint = true;
                            i++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    yield return number;
                }
                else
                {
                    token += c;
                    i++;
                }
            }

            if (!string.IsNullOrEmpty(token))
            {
                yield return token;
            }
        }


        private static int GetPrecedence(string op)
        {
            switch (op)
            {
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                default:
                    return 0;
            }
        }

        private static IEnumerable<string> ConvertToPostfix(IEnumerable<string> tokens)
        {
            var outputQueue = new Queue<string>();
            var operatorStack = new Stack<string>();

            foreach (var token in tokens)
                if (double.TryParse(token, out _))
                {
                    outputQueue.Enqueue(token);
                }
                else if (token == "(")
                {
                    operatorStack.Push(token);
                }
                else if (token == ")")
                {
                    while (operatorStack.Any() && operatorStack.Peek() != "(") outputQueue.Enqueue(operatorStack.Pop());

                    if (operatorStack.Any() && operatorStack.Peek() == "(") operatorStack.Pop();
                }
                else
                {
                    while (operatorStack.Any() && GetPrecedence(operatorStack.Peek()) >= GetPrecedence(token)) outputQueue.Enqueue(operatorStack.Pop());

                    operatorStack.Push(token);
                }

            while (operatorStack.Any()) outputQueue.Enqueue(operatorStack.Pop());

            return outputQueue;
        }

        private static double EvaluatePostfix(IEnumerable<string> postfixTokens)
        {
            var operandStack = new Stack<double>();

            foreach (var token in postfixTokens)
                if (double.TryParse(token, out var value))
                {
                    operandStack.Push(value);
                }
                else if (token == "Math.PI")
                {
                    operandStack.Push(Math.PI);
                }
                else
                {
                    var b = operandStack.Pop();
                    var a = operandStack.Pop();

                    switch (token)
                    {
                        case "+":
                            operandStack.Push(a + b);
                            break;
                        case "-":
                            operandStack.Push(a - b);
                            break;
                        case "*":
                            operandStack.Push(a * b);
                            break;
                        case "/":
                            operandStack.Push(a / b);
                            break;
                    }
                }

            return operandStack.Pop();
        }
    }
}