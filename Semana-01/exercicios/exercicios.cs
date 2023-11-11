/* 2 Tipos de Dados:
Problema: Quais são os tipos de dados numéricos inteiros disponíveis no .NET? 
Dê exemplos de uso para cada um deles através de exemplos.*/

#region "Tipos de Dados"

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

#endregion

/* 3. Conversão de Tipos de Dados:
Problema: Suponha que você tenha uma variável do tipo double e deseja convertê-la 
em um tipo int. Como você faria essa conversão e o que aconteceria se a parte 
fracionária da variável double não pudesse ser convertida em um int? Resolva o 
problema através de um exemplo em C#.*/

#region egion "Conversão de Tipos de Dados"

double valorDouble = 3.14;
int valor_Int = Convert.ToInt32(valorDouble);
Console.WriteLine(valorInt); 

#endregion

/* 4. Operadores Aritméticos:
Problema: Dada a variável int x = 10 e a variável int y = 3, escreva código para calcular 
e exibir o resultado da adição, subtração, multiplicação e divisão de x por y.*/

#region "Operadores Aritméticos"

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

#endregion

/* 5. Operadores de Comparação:
Problema: Considere as variáveis int a = 5 e int b = 8. 
Escreva código para determinar se a é maior que b e exiba o resultado.*/

#region "Operadores de Comparação"

int a = 5;
int b = 8;

if (a > b)
{
    Console.WriteLine("a é maior que b");
}
else
{
    Console.WriteLine("b é maior que a");
}

#endregion

/* 6. Operadores de Igualdade:
Problema: Você tem duas strings, string str1 = "Hello" e string str2 = "World". Escreva 
código para verificar se as duas strings são iguais e exibir o resultado. */

#region "Operadores de Igualdade"

string str1 = "Hello";
string str2 = "World";

if (str1 == str2)
{
    Console.WriteLine("As strings são iguais");
}
else
{
    Console.WriteLine("As strings são diferentes");
}

#endregion

/* 7. Operadores Lógicos:
Problema: Suponha que você tenha duas variáveis booleanas, bool condicao1 = true 
e bool condicao2 = false. Escreva código para verificar se ambas as condições são 
verdadeiras e exiba o resultado.*/

#region "Operadores Lógicos"

bool condicao1 = true;
bool condicao2 = false;

if (condicao1 && condicao2)
{
    Console.WriteLine("Ambas as condições são verdadeiras");
}
else
{
    Console.WriteLine("Pelo menos uma das condições é falsa");
}

#endregion

/* 8. Desafio de Mistura de Operadores:
Problema: Dadas as variáveis int num1 = 7, int num2 = 3, e int num3 = 10, escreva 
código para verificar se num1 é maior do que num2 e se num3 é igual a num1 + num2.*/

#region "Desafio de Mistura de Operadores"

int num1 = 7;
int num2 = 3;
int num3 = 10;

if (num1 > num2 && num3 == num1 + num2)
{
    Console.WriteLine("num1 é maior que num2 e num3 é igual a num1 + num2");
}
else
{
    Console.WriteLine("As condições não são satisfeitas");
}

#endregion







