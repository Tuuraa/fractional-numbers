using System;

namespace Fractionals
{
    public class Fractional : IComparable, IConvertible
    {
        private int _numerator = 0;
        private int _denominator = 1;
        private int _whole_number = 0;

        /// <summary>
        /// Class constructor by using another fractional number 
        /// </summary>
        /// <param name="fractional"></param>
        public Fractional(Fractional fractional)
        {
            this._numerator = fractional._numerator;
            this._denominator = fractional._denominator;
        }
        /// <summary>
        /// Class constructor by using two integer variables 
        /// </summary>
        /// <param name="numer"></param>
        /// <param name="denomer"></param>
        public Fractional(int numer, int denomer)
        {
            this._numerator = numer;
            this._denominator = denomer;
        }
        /// <summary>
        /// Class constructor by using string variable as fractional number
        /// </summary>
        /// <param name="number"></param>
        /// <exception cref="ArgumentException"></exception>
        ///<example>
        /// <code>
        ///     Fanctional fanc = new Fanctional("-3/4");
        /// </code>
        ///</example>
        public Fractional(string number)
        {
            if (number.IndexOf("/") == -1) throw new ArgumentException();
            
            int start = number.IndexOf("-");
            int index = number.IndexOf("/");

            string str = string.Empty;

            for (int i = start; i < index; i++)
                str += number[i]; 

            _numerator = int.Parse(str);
            str = string.Empty;

            for (int i = ++index; i < number.Length; i++)
                str += number[i];

            _denominator = int.Parse(str);

        }
        /// <summary>
        /// Returns the numerator
        /// </summary>
        /// <returns>_numerator</returns>
        public int GetNumerator() => _numerator;
        /// <summary>
        /// Returns the denominator
        /// </summary>
        /// <returns>_numerator</returns>
        public int GetDenominator() => _denominator;
        /// <summary>
        /// Returns the whole number (integer)
        /// </summary>
        /// <returns>_whole_number</returns>
        public int GetWholeNumber() => _numerator / _denominator;
        /// <summary>
        /// Returns the decimal number
        /// </summary>
        /// <returns>double</returns>
        public double GetDecimal() => (double)_numerator / _denominator;
        private double GetPositivelyDecimal() => (double)Math.Abs(_numerator) / _denominator;
        /// <summary>
        /// Swaps _numerator and deniminator
        /// </summary>
        /// <returns>void</returns>
        public void Swap()
        {
            var temp = _numerator;
            _numerator = _denominator;
            _denominator = temp;
        }
        /// <summary>
        /// Create whole number in this class
        /// </summary>
        public void CreateWholeNumber()
        {
            _whole_number = _numerator / _denominator;
            _numerator = _numerator > 0 ? _numerator - _whole_number * _denominator 
                : Math.Abs(_numerator - _whole_number * _denominator);
        } 
        /// <summary>
        /// Return internal view
        /// </summary>
        public void ReturnFractional()
        {
            if (_whole_number == 0) return;
            _numerator = _whole_number > 0 ? _numerator + _whole_number * _denominator 
                : -(_numerator - _whole_number * _denominator);
            _whole_number = 0;
        }
        /// <summary>
        /// Change the numerator
        /// </summary>
        /// <param name="value"></param>
        public void ChangeNumerator(int value) => _numerator = value;
        /// <summary>
        /// Change the denominator
        /// </summary>
        /// <param name="value"></param>
        public void ChangeDenominator(int value) => _denominator = value;
        /// <summary>
        /// Change thenumerator and denominator
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        public void ChangeAll(int value1, int value2)
        {
            _numerator = value1;
            _denominator = value2;
        }
        /// <summary>
        /// Exponentiate the fractional number
        /// </summary>
        /// <param name="fractional"></param>
        /// <param name="degree"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Fractional Exponentiate(Fractional fractional, int degree)
        {
            if (fractional is null) throw new ArgumentNullException(nameof(fractional));

            if (degree > 0)
                return new Fractional(
                    (int)Math.Pow(fractional._numerator, degree),
                    (int)Math.Pow(fractional._denominator, degree));
            if (degree == 0)
                return new Fractional(1, 1);
            else
            {
                return new Fractional(
                    (int)Math.Pow(fractional._denominator, degree),
                    (int)Math.Pow(fractional._numerator, degree));
            }
        }
        /// <summary>
        /// Exponentiate the fractional number in fractional number
        /// </summary>
        /// <param name="fractional"></param>
        /// <param name="degree"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Fractional Exponentiate(Fractional fractional, Fractional degree)
        {
            if (degree is null) throw new ArgumentNullException(nameof(degree));
            if (fractional is null) throw new ArgumentNullException(nameof(degree));

            if (degree._numerator == 0)
                return new Fractional(0, 1);

            if (degree._numerator > 0)
            {
                return new Fractional(
                    (int)Math.Pow(fractional._numerator, degree.GetDecimal()),
                    (int)Math.Pow(fractional._denominator, degree.GetDecimal()));
            }
            else
                return new Fractional(
                    (int)Math.Pow(fractional._denominator, degree.GetPositivelyDecimal()),
                    (int)Math.Pow(fractional._numerator, degree.GetPositivelyDecimal()));
        }

        public static Fractional operator -(Fractional fc1, Fractional fc2)
        {
            if (fc1 is null || fc2 is null)
                throw new ArgumentNullException(nameof(fc1));

            else
            {
                if (fc1._numerator > 0 && fc2._numerator > 0)
                {
                    if (!fc1._denominator.Equals(fc2._denominator))
                    {
                        int newDenominator = fc1._denominator * fc2._denominator;
                        int Newnumerator1 = fc1._numerator; Newnumerator1 *= newDenominator / fc1._denominator;
                        int Newnumerator2 = fc2._numerator; Newnumerator2 *= newDenominator / fc2._denominator;

                        return new Fractional(
                            Newnumerator1 - Newnumerator2,
                            newDenominator);
                    }

                    else //if (fc1.denominator.Equals(fc2.denominator))
                    {
                        return new Fractional(
                            fc1._numerator - fc2._numerator,
                            fc1._denominator);
                    }
                }

                else
                {
                    if ((fc1._numerator < 0 && fc2._numerator < 0) && (fc1._denominator == fc2._denominator))
                    {
                        return new Fractional(
                            fc1._numerator - fc2._numerator,
                            fc1._denominator);
                    }

                    if (fc1._numerator < 0 && fc2._numerator < 0)
                    {
                        int newDenominator = fc1._denominator * fc2._denominator;
                        int Newnumerator1 = fc1._numerator; Newnumerator1 *= newDenominator / fc1._denominator;
                        int Newnumerator2 = fc2._numerator; Newnumerator2 *= newDenominator / fc2._denominator;

                        if (Newnumerator2 < 0)
                            return new Fractional(
                                Newnumerator1 - Newnumerator2,
                                newDenominator);

                        return new Fractional(
                            Newnumerator1 + Newnumerator2,
                            newDenominator);
                    }

                    else //if (fc1.sigh == -1 || fc2.sigh == -1)
                    {

                        if (!fc1._denominator.Equals(fc2._denominator))
                        {
                            if ((Math.Abs(fc1._numerator) == Math.Abs(fc2._numerator) && fc2._numerator > 0) ||
                                (Math.Abs(fc2._numerator) == Math.Abs(fc1._numerator) && fc1._numerator > 0))
                                return new Fractional(0, 1);

                            else
                            {
                                int newDenominator = fc1._denominator * fc2._denominator;
                                int Newnumerator1 = fc1._numerator; Newnumerator1 *= newDenominator / fc1._denominator;
                                int Newnumerator2 = fc2._numerator; Newnumerator2 *= newDenominator / fc2._denominator;

                                if (Newnumerator2 < 0)
                                    return new Fractional(
                                        Newnumerator1 - Newnumerator2,
                                        newDenominator);

                                return new Fractional(
                                    Newnumerator1 - Newnumerator2,
                                    newDenominator);
                            }
                        }

                        else
                        {
                            if (fc1._denominator.Equals(fc2._denominator))
                            {
                                
                                return new Fractional(
                                    fc1._numerator - fc2._numerator,
                                    fc1._denominator);
                            }
                            else throw new Exception();
                        }


                    }
                }
            }

        }
        public static Fractional operator +(Fractional fc1, Fractional fc2)
        {
            if (fc1 is null || fc2 is null)
                throw new ArgumentNullException(nameof(fc1));

            else
            {
                if (fc1._numerator > 0 && fc2._numerator > 0)
                {
                    if (!fc1._denominator.Equals(fc2._denominator))
                    {
                        int newDenominator = fc1._denominator * fc2._denominator;
                        int Newnumerator1 = fc1._numerator; Newnumerator1 *= newDenominator / fc1._denominator;
                        int Newnumerator2 = fc2._numerator; Newnumerator2 *= newDenominator / fc2._denominator;

                        return new Fractional(
                            Newnumerator1 + Newnumerator2,
                            newDenominator
                            );
                    }

                    else //if (fc1.denominator.Equals(fc2.denominator))
                    {
                        return new Fractional(
                            fc1._numerator + fc2._numerator,
                            fc1._denominator);
                    }
                }

                else
                {
                    if ((fc1._numerator < 0 && fc2._numerator < 0) && (fc1._denominator == fc2._denominator))
                    {
                        return new Fractional(
                            fc1._numerator + fc2._numerator,
                            fc1._denominator);
                    }

                    if (fc1._numerator < 0 && fc2._numerator < 0)
                    {
                        int newDenominator = fc1._denominator * fc2._denominator;
                        int Newnumerator1 = fc1._numerator; Newnumerator1 *= newDenominator / fc1._denominator;
                        int Newnumerator2 = fc2._numerator; Newnumerator2 *= newDenominator / fc2._denominator;

                        return new Fractional(
                            Newnumerator1 + Newnumerator2,
                            newDenominator);
                    }

                    else //if (fc1.sigh == -1 || fc2.sigh == -1)
                    {

                        if (!fc1._denominator.Equals(fc2._denominator))
                        {
                            if (Math.Abs(fc1._numerator) == Math.Abs(fc2._numerator))
                                return new Fractional(
                                    0, 1);
                            else
                            {
                                int newDenominator = fc1._denominator * fc2._denominator;
                                int Newnumerator1 = fc1._numerator; Newnumerator1 *= newDenominator / fc1._denominator;
                                int Newnumerator2 = fc2._numerator; Newnumerator2 *= newDenominator / fc2._denominator;

                                return new Fractional(
                                    Newnumerator1 +Newnumerator2,
                                    newDenominator);
                            }
                        }

                        else
                        {
                            if (fc1._denominator.Equals(fc2._denominator))
                            {
                                return new Fractional(
                                    fc1._numerator + fc2._numerator,
                                    fc1._denominator);
                            }
                            else throw new Exception();
                        }
                        

                    }
                }
            }
        }
        public static Fractional operator *(Fractional fc1, Fractional fc2)
        {
            if (fc1 is null || fc2 is null)
                throw new ArgumentNullException(nameof(fc1));
            else
            {
                return new Fractional(
                    fc1._numerator * fc2._numerator,
                    fc1._denominator * fc2._denominator);
            }
        }
        public static Fractional operator /(Fractional fc1, Fractional fc2)
        {
            if (fc1 is null || fc2 is null)
                throw new ArgumentNullException(nameof(fc1));
            else
            {

                return new Fractional(
                    fc1._numerator * fc2._denominator,
                    fc1._denominator * fc2._numerator);
            }
        }
        public static bool operator >(Fractional fc1, Fractional fc2)
        {
            if (fc1._numerator > fc2._numerator && fc1._denominator > fc2._denominator) return true;
            else return false;
        }
        public static bool operator <(Fractional fc1, Fractional fc2)
        {
            if (fc1._numerator < fc2._numerator && fc1._denominator < fc2._denominator) return true;
            else return false;
        }
        public static bool operator ==(Fractional fc1, Fractional fc2)
        {
            if (fc1._numerator == fc2._numerator && fc1._denominator == fc2._denominator) return true;
            else return false;
        }
        public static bool operator !=(Fractional fc1, Fractional fc2)
        {
            if (fc1._numerator == fc2._numerator && fc1._denominator == fc2._denominator) return false;
            else return true;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;

            if (obj is Fractional frac)
            {
                if (this._numerator == frac._numerator &&
                    this._denominator == frac._denominator) return true;

                else return false;
            }

            else return false;
        }
        public override string ToString()
        {
            if (_numerator == 0)
                return "0";
            if (this._numerator > 0)
                return _numerator + "/" + _denominator;

            else return _numerator + "/" + _denominator;
        }
        public override int GetHashCode()
        {
            return _numerator.GetHashCode() ^ _denominator.GetHashCode();
        }
        public int CompareTo(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                throw new ArgumentException();

            Fractional frac = obj as Fractional;

            if (this._numerator > frac._numerator && this._denominator > frac._denominator) return 1;
            if (this._numerator == frac._numerator && this._denominator == frac._denominator) return 0;
            else return -1;
        }

        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }
        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
        public byte ToByte(IFormatProvider provider) => (byte)GetDecimal();
        public char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
        public decimal ToDecimal(IFormatProvider provider) => (decimal)GetDecimal();
        public double ToDouble(IFormatProvider provider) => GetDecimal();
        public short ToInt16(IFormatProvider provider) => (Int16)GetDecimal();
        public int ToInt32(IFormatProvider provider) => (Int32)GetDecimal();
        public long ToInt64(IFormatProvider provider) => (Int64)GetDecimal();
        public sbyte ToSByte(IFormatProvider provider) => (sbyte)GetDecimal();
        public float ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
        public string ToString(IFormatProvider provider) => this.ToString();
        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
        public ushort ToUInt16(IFormatProvider provider) => (UInt16)GetDecimal();
        public uint ToUInt32(IFormatProvider provider) => (UInt32)GetDecimal();
        public ulong ToUInt64(IFormatProvider provider) => (UInt64)GetDecimal();
    }
}
