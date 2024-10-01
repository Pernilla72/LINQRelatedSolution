namespace LINQRelated;

    internal class Patient: IComparable<Patient>
    {
        public double HeightInCm { get; set; }
        public double WeightInKg { get; set; }

        public int CompareTo(Patient? other)
        {

            if (this.BMI() < other.BMI()) return -1;

            if (this.BMI() > other.BMI()) { return 1; } 

            return 0;
        }

        public override string ToString()
        {
            return $"Längd: {HeightInCm} och vikt: {WeightInKg}";
        }
}

