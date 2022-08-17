using System.Collections.Generic;

namespace AlgoMania.Intermediary
{
    public class MaxConsecutivesOnes
    {
        /*
        Dado um array numbers com valores 0 e 1, nós podemos alterar K valores de 0 para 1.
        Retorne o tamanho do maior subarray contínuo que contém apenas 1.

        Exemplo 1:
        Entrada:
        numbers = [1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0], K = 2
        Saída: 6

        Exemplo 2:
        Entrada:
        numbers = [0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1], K = 3
        Saída: 10
        */

        //Time O(n) - Space O(1)
        public static int maxConsecutivesOnes(List<int> numbers, int k)
        {
            int left_pointer = 0;
            int right_pointer = 0;

            for (; right_pointer < numbers.Count; right_pointer++)
            {
                if (numbers[right_pointer] == 0)
                    k--;

                if (k < 0)
                {
                    if (numbers[left_pointer] == 0)
                        k++;

                    left_pointer++;
                }
            }

            return right_pointer - left_pointer + 1;
        }

        public static int maxConsecutivesOnesV2(List<int> numbers, int k)
        {
            int left_pointer = 0;
            int right_pointer = 0;

            for (; right_pointer < numbers.Count; right_pointer++)
            {
                k -= 1 - numbers[right_pointer];

                if (k < 0)
                {
                    k += 1 - numbers[left_pointer];
                    left_pointer++;
                }
            }

            return right_pointer - left_pointer + 1;
        }
    }
}
