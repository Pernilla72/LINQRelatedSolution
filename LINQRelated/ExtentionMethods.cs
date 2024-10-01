/*
 * Extention Metoder är statiska metoder som skrivs i en statisk klass där
 * den första parametern föregås av nyckelordet this
 */

using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace LINQRelated;

internal static class ExtentionMethods
{                         //Where = betyder "Filtrerar en sekvens av värden baserat på ett villkor
    public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool>precicate)
    {
    //Enumerable  Innehåller Alla LINQ-,etoder. Tryck F1 för info!
    return null;
    }
    public static bool PerCentChance(this int perCent)
    {
        int RandomNumber = Random.Shared.Next(1, 100 +1);
        return  RandomNumber <= perCent;
    }

    public static double BMI(this Patient patient)
    {
        return patient.WeightInKg / ((patient.HeightInCm / 100) * (patient.HeightInCm / 100));
    }


    public static int Square(this int i)
    {
        return i * i;
    }
    public static int Plus10(this int i)
    {
        return i +10;
    }
    public static int DividedBy2(this int i)
    {
        return i /2;
    }
    
    internal static bool IsLessThan<T>(this IComparable<T> first, T second)
    {
        return first.CompareTo(second) == -1;
    }

    public static void Print<T>(this IEnumerable<T> collection)
    {
        foreach (T item in collection)
        {
            Console.WriteLine(item);  
        }
    }

    public static void Print<T>(this IEnumerable<T> collection, Func<T, object> selector)
    {
        foreach (T item in collection)
        {
            Console.WriteLine(selector(item));
        }
    }
}

//Överlagra Print() metoden med en version som tar emot en delegat "selector" som pekar ut vad som
//ska printas: När metoden anropas görs det med: Patient.Print(p => p.HeightInCm)  etc...
//Förklaring:
//Func<T, object>  betyder att detta är en delegat som tar ett argument av typen T och returnerar ett värde av typen object.
//* selector är delegaten(alltså själva funktionen eller lambda-uttrycket) som du skickar in.
//Den refererar till en funktion eller ett lambda-uttryck som tar ett objekt av typen T(i mitt exempel Patient) och returnerar ett värde av
//typen object (t.ex.en egenskap som HeightInCm).
//* object är helt enkelt returtypen för den funktion som delegaten pekar på.Det betyder att den funktion som selector pekar på ska
//returnera något som kan vara av vilken typ som helst, vilket vi uttrycker som object (den mest generella typen i C#).
