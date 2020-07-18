namespace studentOrganizer
{
    public struct RatingSubject
    {
        public string Semester { get; set; } // номер семестра
        public string SubjectName { get; set; } // название предмета
        public string Type { get; set; } // Тип
        public string FinalScore { get; set; } // Итоговый балл
        public string Term { get; set; } // срок
        public string FirstCheckPointScore { get; set; } // баллы 1-й КТ 
        public string SecondCheckPointScore { get; set; } // баллы 2-й КТ
        public string ThirdCheckPointScore { get; set; } // баллы 3-й КТ
        public string NumberOfAbsenteeismAtTheFirstCheckpoint { get; set; } // прогулы в 1-й КТ
        public string NumberOfAbsenteeismAtTheSecondCheckpoint { get; set; } // прогулы во 2-й КТ
        public string NumberOfAbsenteeismAtTheThirdCheckpoint { get; set; } // прогулы в 3-й КТ
    }
}