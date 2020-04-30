using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
	enum Faculties
	{
		Fre = 0,
		Fkp = 1,
		Fksis,
		Fitu,
		Ief,
		Fik,
		Fino
	};

	class Person
	{
		public static int Id = 0;

		protected struct Information
		{
			static string _Surname = " ";
			static string _Name = " ";
			static string _Fathername;

			static internal string Surname
			{
				get => _Surname;
				set

				{
					if (Regex.Match(value, "[а-яА-Я]").Success)
					{
						_Surname = value;
					}
				}
			}

			static internal string Name
			{
				get => _Name;
				set

				{
					if (Regex.Match(value, "[а-яА-Я]").Success)
					{
						_Name = value;
					}
				}
			}

			static internal string Fathername
			{
				get => _Fathername;
				set

				{
					if (Regex.Match(value, "[а-яА-Я]").Success)
					{
						_Fathername = value;
					}
				}
			}
		}


		public Person(string surname, string name, string fathername) =>
			(Information.Surname, Information.Name, Information.Fathername,Id)
			= (surname, name, fathername,++Id);

		// ИНДЕКСАТОР

		public string this[string propname]
		{
			get
			{
				switch (propname)
				{
					case "surname": return Information.Surname;
					case "name": return Information.Name;
					default: return "Doesn't FIND";
				}
			}
			set
			{
				switch (propname)
				{
					case "surname":
						Information.Surname = value;
						break;
					case "name":
						Information.Name = value;
						break;
					default:
						break;
				}
			}
		}
		public virtual string Print() => $"{Information.Surname} {Information.Name} {Information.Fathername}";
	}

	class Student : Person
	{
		public string Name_University { get; set; }
		public Student(string surname, string name, string fathername, string name_university) : base(surname, name, fathername)
		{
			this.Name_University = name_university;
		}
		public override string Print() => $"{Information.Surname} {Information.Name} {Information.Fathername} {Name_University}";
	}

	class Student_Speciality : Person
	{
		public String Faculty { get; set; }
		public string Group { get; set; }

		public Student_Speciality(string surname, string name, string fathername, int faculty, string group) :
			base(surname, name, fathername)
		{
			this.Faculty = Enum.GetName(typeof(Faculties), faculty);
			this.Group = group;
		}

		public override string Print() => $"{Information.Surname} {Information.Name} {Information.Fathername} {Faculty} {Group}";

		public void AddToPrint(params string[] args)
		{
			Console.Write(Print());
			foreach (var x in args)
			{
				Console.Write(" "+x);
			}
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Person test1 = new Person("Иванов", "Иван", "Иванович");
			Console.WriteLine(test1.Print());
			Student test2 = new Student("Бойко", "Владислав", "Богданович","БГУИР");
			Console.WriteLine(test2.Print());
			Student_Speciality test3 = new Student_Speciality("Бойко", "Владислав", "Богданович", 0, "944691");
			Console.WriteLine(test3.Print());
			test3.AddToPrint("инфа1", "инфа2", "инфа3", "инфа 4");
			Console.ReadKey();
		}
	}
}

