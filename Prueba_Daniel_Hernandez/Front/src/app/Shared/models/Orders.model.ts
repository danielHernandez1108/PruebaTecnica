export interface Exam {
  // Define properties of Exam here
  id: number;
  nameExam: string;
  // Add other fields as necessary
}

export interface Orders {
  id: number;
  namePatient: string;
  exams: Exam[]; // corrected and named
}


