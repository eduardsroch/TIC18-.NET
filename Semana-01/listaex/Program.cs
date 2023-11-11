/// <summary>
/// 2 Tipos de Dados:
/// Problema: Quais são os tipos de dados numéricos inteiros disponíveis no .NET? Dê exemplos de uso para cada um deles através de exemplos.
/// </summary>


sbyte valorSbyte = -128; // armazena valores de -128 a 127
Console.WriteLine(valorSbyte);

byte valorByte = 255; // armazena valores de 0 a 255
Console.WriteLine(valorByte);

short valorShort = -32768; // armazena valores de -32768 a 32767
Console.WriteLine(valorShort);

ushort valorUshort = 65535; // armazena valores de 0 a 65535
Console.WriteLine(valorUshort);

int valorInt = -2147483648; // armazena valores de -2147483648 a 2147483647
Console.WriteLine(valorInt);

uint valorUint = 4294967295; // armazena valores de 0 a 4294967295
Console.WriteLine(valorUint);

long valorLong = -9223372036854775808; // armazena valores de -9223372036854775808 a 9223372036854775807
Console.WriteLine(valorLong);

ulong valorUlong = 18446744073709551615; // armazena valores de 0 a 18446744073709551615
Console.WriteLine(valorUlong);

/// <summary>
/// 3. Conversão de Tipos de Dados:
//Problema: Suponha que você tenha uma variável do tipo double e deseja convertê-la 
//em um tipo int. Como você faria essa conversão e o que aconteceria se a parte 
//fracionária da variável double não pudesse ser convertida em um int? Resolva o 
//problema através de um exemplo em C#.
/// </summary>

double valorDouble = 3.14;
int valor_Int = Convert.ToInt32(valorDouble);
Console.WriteLine(valorInt); 

/// <summary>
/// 4. Operadores Aritméticos:
//Problema: Dada a variável int x = 10 e a variável int y = 3, escreva código para calcular 
//e exibir o resultado da adição, subtração, multiplicação e divisão de x por y.
/// </summary>

int x = 10;
int y = 3;

int soma = x + y;
int subtracao = x - y;
int multiplicacao = x * y;
int divisao = x / y;

Console.WriteLine($"Soma: {soma}");
Console.WriteLine($"Subtração: {subtracao}");
Console.WriteLine($"Multiplicação: {multiplicacao}");
Console.WriteLine($"Divisão: {divisao}");

/// <summary>
/// 
/// <summary>






