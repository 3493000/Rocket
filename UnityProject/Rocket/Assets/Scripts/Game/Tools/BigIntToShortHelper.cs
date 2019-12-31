using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hunter;
using System.Text;

namespace Hunter
{
    public class BigIntToShortHelper
    {
        private static long m_Billion = 1000000000;
        private static long m_Million = 1000000;
        private static long m_Thousand = 1000;



        public static string BigToShortString(BigInteger num)
        {
            if (num >= m_Billion)
            {
                return GetString(num, m_Billion,"B");
            }
            else if (num>=m_Million)
            {
                return GetString(num ,m_Million,"M");
            }
            else if(num >= m_Thousand)
            {
                return GetString(num, m_Thousand, "K");
            }
            else
            {
                return num.ToString();
            }
        }

        private static string GetString(BigInteger num , BigInteger index ,string sympol)
        {
            return string.Format(num / index + "." + (num % index) / (index / 10) + sympol);
        }

        private static string GetString1(BigInteger num, BigInteger index, string sympol)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}.{1}", num / index, (num % index) / (index / 10) + sympol);
            return sb.ToString();
        }

    }


    public class StringHelper
    {
        private static BigInteger THOUSAND = 1000;
        private static BigInteger MILLION = 1000000;
        private static BigInteger BILLION = 1000000000;
        private static BigInteger TRILLION = 1000000000000;
        private static BigInteger Q_BIG = 1000000000000000;

        private static BigInteger Y_BIG = new BigInteger("1000000000000000000");
        private static BigInteger U_BIG = new BigInteger("1000000000000000000000");
        private static BigInteger P_BIG = new BigInteger("1000000000000000000000000");
        private static BigInteger E_BIG = new BigInteger("1000000000000000000000000000");
        private static BigInteger R_BIG = new BigInteger("1000000000000000000000000000000");
        private static BigInteger N_BIG = new BigInteger("1000000000000000000000000000000000");
        private static BigInteger G_BIG = new BigInteger("1000000000000000000000000000000000000");
        private static BigInteger H_BIG = new BigInteger("1000000000000000000000000000000000000000");
        private static BigInteger L_BIG = new BigInteger("1000000000000000000000000000000000000000000");
        private static BigInteger S_BIG = new BigInteger("1000000000000000000000000000000000000000000000");
        private static BigInteger V_BIG = new BigInteger("1000000000000000000000000000000000000000000000000");
        private static BigInteger X_BIG = new BigInteger("1000000000000000000000000000000000000000000000000000");
        private static BigInteger Z_BIG = new BigInteger("1000000000000000000000000000000000000000000000000000000");
        private static BigInteger D_BIG = new BigInteger("1000000000000000000000000000000000000000000000000000000000");
        private static BigInteger F_BIG = new BigInteger("1000000000000000000000000000000000000000000000000000000000000");
        private static BigInteger W_BIG = new BigInteger("1000000000000000000000000000000000000000000000000000000000000000");
        private static BigInteger O_BIG = new BigInteger("1000000000000000000000000000000000000000000000000000000000000000000");
        private static BigInteger C_BIG = new BigInteger("1000000000000000000000000000000000000000000000000000000000000000000000");      
        private static BigInteger I_BIG = new BigInteger("1000000000000000000000000000000000000000000000000000000000000000000000000");
        private static BigInteger J_BIG = new BigInteger("1000000000000000000000000000000000000000000000000000000000000000000000000000");
        private static BigInteger A_BIG = new BigInteger("1000000000000000000000000000000000000000000000000000000000000000000000000000000");


        public static string FormatBigMoney(BigInteger num)
        {
            if (num >= A_BIG)
            {
                return GetString(num, A_BIG, "A");
            }
            else if (num >= J_BIG)
            {
                return GetString(num, J_BIG, "J");
            }
            else if (num >= I_BIG)
            {
                return GetString(num, I_BIG, "I");
            }
            else if (num >= C_BIG)
            {
                return GetString(num, C_BIG, "C");
            }
            else if (num >= O_BIG)
            {
                return GetString(num, O_BIG, "O");
            }
            else if (num >= W_BIG)
            {
                return GetString(num, W_BIG, "W");
            }
            else if (num >= F_BIG)
            {
                return GetString(num, F_BIG, "F");
            }
            else if (num >= D_BIG)
            {
                return GetString(num, D_BIG, "D");
            }
            else if (num >= Z_BIG)
            {
                return GetString(num, Z_BIG, "Z");
            }
            else if (num >= X_BIG)
            {
                return GetString(num, X_BIG, "X");
            }
            else if (num >= V_BIG)
            {
                return GetString(num, V_BIG, "V");
            }
            else if (num >= S_BIG)
            {
                return GetString(num, S_BIG, "S");
            }
            else if (num >= L_BIG)
            {
                return GetString(num, L_BIG, "L");
            }
            else if (num >= H_BIG)
            {
                return GetString(num, H_BIG, "H");
            }
            else if(num >= G_BIG)
            {
                return GetString(num, G_BIG, "G");
            }
            else if(num >= N_BIG)
            {
                return GetString(num, N_BIG, "N");
            }
            else if(num >= R_BIG)
            {
                return GetString(num, R_BIG, "R");
            }
            else if(num >= E_BIG)
            {
                return GetString(num, E_BIG, "E");
            }
            else if(num >= P_BIG)
            {
                return GetString(num, P_BIG, "P");
            }
            else if(num >= U_BIG)
            {
                return GetString(num, U_BIG, "U");
            }
            else if(num >= Y_BIG)
            {
                return GetString(num, Y_BIG, "Y");
            }
            else if(num >= Q_BIG)
            {
                return GetString(num, Q_BIG, "Q");
            }
            else if (num >= TRILLION)
            {
                return GetString(num, TRILLION, "T");
            }
            else if (num >= BILLION)
            {
                return GetString(num, BILLION, "B");
            }
            else if (num >= MILLION)
            {
                return GetString(num, MILLION, "M");
            }
            else if (num >= THOUSAND)
            {
                return GetString(num, THOUSAND, "K");
            }
            else
            {
                return num.ToString();
            }
        }

        static string GetString(BigInteger num, BigInteger index, string sympol)
        {
            int afterDot = int.Parse(((num % index) / (index / 100)).ToString());
            return string.Format("{0}.{1:D2}{2}", num / index, afterDot, sympol);
        }

    }

}