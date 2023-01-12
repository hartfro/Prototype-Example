using System;

namespace RefactoringGuru.DesignPatterns.Prototype.Conceptual
{
    public class Person
    {
        public int Age;
        public DateTime BirthDate;
        public string Name;
        public IdInfo IdInfo;

        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person clone = (Person)this.MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            clone.Name = String.Copy(Name);
            return clone;
        }
    }

    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Age = 42;
            p1.BirthDate = Convert.ToDateTime("1977-01-01");
            p1.Name = "Simone Barthes";
            p1.IdInfo = new IdInfo(666);

            // Genera una copia vacía de p1 y la asigna a p2
            Person p2 = p1.ShallowCopy();
            // Genera una copia completa de p1 y la asigna a p3
            Person p3 = p1.DeepCopy();

            // Muestra los valores de p1, p2 y p3
            Console.WriteLine("Valores originales de p1, p2, p3:");
            Console.WriteLine("   valores de instancia de p1: ");
            DisplayValues(p1);
            Console.WriteLine("   valores de instancia de p2:");
            DisplayValues(p2);
            Console.WriteLine("   valores de instancia de p3:");
            DisplayValues(p3);

            // Cambia el valor de las propiedades de p1 y muestra los valores
            // de p1, p2 y p3
            p1.Age = 32;
            p1.BirthDate = Convert.ToDateTime("1900-01-01");
            p1.Name = "Julia";
            p1.IdInfo.IdNumber = 7878;
            Console.WriteLine("\nValores de p1, p2 y p3 después de cambios a p1:");
            Console.WriteLine("   valores de instancia de p1: ");
            DisplayValues(p1);
            Console.WriteLine("   valores de instancia de p2 (los valores de referencia han cambiado):");
            DisplayValues(p2);
            Console.WriteLine("   valores de instancia de p3 (todo se mantiene igual):");
            DisplayValues(p3);
        }

        public static void DisplayValues(Person p)
        {
            Console.WriteLine("      Nombre: {0:s}, Edad: {1:d}, FechaNac: {2:MM/dd/yy}",
                p.Name, p.Age, p.BirthDate);
            Console.WriteLine("      ID#: {0:d}", p.IdInfo.IdNumber);
        }
    }
}