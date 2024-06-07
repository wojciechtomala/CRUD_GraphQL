import { Injectable } from '@angular/core';
import { Apollo, gql } from 'apollo-angular';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class StudentService {

  constructor(private apollo: Apollo) { }

  getStudents(): Observable<any> {
    const GET_STUDENTS = gql`
      query {
        groups {
          nodes {
            groupId
            name
            shortName
          }
        }
      }
    `;

    return this.apollo.watchQuery<any>({
      query: GET_STUDENTS
    })
    .valueChanges
    .pipe(
      map(result => result.data.students)
    );
  }
}