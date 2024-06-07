import { Component, OnInit } from '@angular/core';
import { StudentService } from '../student.service';
import { NgFor, NgIf } from '@angular/common';

@Component({
  standalone: true,
  selector: 'app-student-list',
  templateUrl: './studentlist.component.html',
  styleUrls: ['./studentlist.component.css'],
  imports: [NgFor, NgIf]
})
export class StudentListComponent implements OnInit {
  students: any[] = [];

  constructor(private studentService: StudentService) { }

  ngOnInit(): void {
    this.studentService.getStudents().subscribe(data => {
      this.students = data;
    });
  }
}
