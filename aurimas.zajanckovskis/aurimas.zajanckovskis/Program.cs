using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aurimas.zajanckovskis
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] building;
			int numberOfFloors;
			Console.Write("Enter number of floors in a building: ");
			bool result = int.TryParse(Console.ReadLine(), out numberOfFloors);
			if (result == false)
			{
				Console.WriteLine("Wrong format!");
			}


			int whereStaysIntact = random(numberOfFloors);

			createArrayOfFloors(out building, in numberOfFloors);

			int highestIntactFloor = findHighestFloorWhereBreaks(building, whereStaysIntact);

			Console.WriteLine("Highest floor where Egg stays intact :");
			Console.Write(highestIntactFloor);

			Console.Read();
		}

		/// <summary>
		/// Fills array with variables(floors)
		/// </summary>
		/// <param name="building"></param>
		/// <param name="numberOfFloors"></param>
		static void createArrayOfFloors(out int[] building, in int numberOfFloors)
		{
			building = new int[numberOfFloors];

			for (int i = 0; i < building.Length; i++)
			{
				building[i] = i;
			}
		}

		/// <summary>
		/// Finds highest floor where egg breaks
		/// </summary>
		/// <param name="array"></param>
		/// <param name="whereBreaks"></param>
		/// <returns></returns>
		static int findHighestFloorWhereBreaks(int[] array, int whereBreaks)
		{

			int middleFloor = (array.Length/2);
			int result = 0;

			if (isHigher(middleFloor, whereBreaks))
			{
				result = searchFloors(array,middleFloor - 1, array.Length, whereBreaks);
			}
			result = searchFloors(array, 0, middleFloor, whereBreaks);

			return result;

		}

		/// <summary>
		/// Search floors for choosen value
		/// </summary>
		/// <param name="array"></param>
		/// <param name="index"></param>
		/// <param name="End"></param>
		/// <param name="whereBreaks"></param>
		/// <returns></returns>
		static int searchFloors(in int[] array, int index, int End,int whereBreaks)
		{
			for (int i = index; i < End; i++)
			{
				if (array[i] == whereBreaks)
				{
					whereBreaks = i;
					break;
				}
			}
			return whereBreaks;
		}

		/// <summary>
		/// Looks if selected value is higher then the middle element of the array(for faster search method)
		/// </summary>
		/// <param name="middleFloor"></param>
		/// <param name="whereBreaks"></param>
		/// <returns></returns>
		static bool isHigher(int middleFloor, int whereBreaks)
		{
			bool isHigher = (whereBreaks > middleFloor) ? true : false;
			return isHigher;
		}

		/// <summary>
		/// Creates random value
		/// </summary>
		/// <param name="highest"></param>
		/// <returns></returns>
		static int random(int highest)
		{
			Random rn = new Random();
			return rn.Next(0, highest);
		}
	}
}
