using System;

public class Matrix
{
    private double[,] data;

    public Matrix(int m, int n)
    {
        data = new double[m, n];
    }

    public Matrix(int n) : this(n, n) { }

    public Matrix() : this(3, 3) { }

    
    public void Fill(double value)
    {
        for (int i = 0; i < data.GetLength(0); i++)
        {
            for (int j = 0; j < data.GetLength(1); j++)
            {
                data[i, j] = value;
            }
        }
    }

    
    public int Rows => data.GetLength(0);
    public int Columns => data.GetLength(1);

    
    public static Matrix Sum(Matrix A, Matrix B)
    {
        if (A.Rows != B.Rows || A.Columns != B.Columns)
        {
            throw new ArgumentException("A két mátrixnak azonos méretűnek kell lennie.");
        }

        Matrix result = new Matrix(A.Rows, A.Columns);
        for (int i = 0; i < A.Rows; i++)
        {
            for (int j = 0; j < A.Columns; j++)
            {
                result.data[i, j] = A.data[i, j] + B.data[i, j];
            }
        }
        return result;
    }

   
    public override string ToString()
    {
        string result = "";
        for (int i = 0; i < data.GetLength(0); i++)
        {
            result += "|";
            for (int j = 0; j < data.GetLength(1); j++)
            {
                result += data[i, j].ToString();
                if (j < data.GetLength(1) - 1)
                {
                    result += ", ";
                }
            }
            result += "|\n";
        }
        return result;
    }

    
}


public class Program
{
    public static void Main()
    {
        Matrix matrix1 = new Matrix(2, 3);
        matrix1.Fill(5);
        Console.WriteLine("Mátrix 1:");
        Console.WriteLine(matrix1);

        Matrix matrix2 = new Matrix(2, 3);
        matrix2.Fill(3);
        Console.WriteLine("Mátrix 2:");
        Console.WriteLine(matrix2);

        Matrix sumMatrix = Matrix.Sum(matrix1, matrix2);
        Console.WriteLine("A két mátrix összege:");
        Console.WriteLine(sumMatrix);
    }
}