import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Questionnaire } from '../models/Questionnaire';

@Injectable({
    providedIn: 'root'
})
export class QuestionnaireService {

    baseUrl = 'https://localhost:7150/questionnaire';

    headers = new HttpHeaders().set('content-type', 'application/json').set('Access-Control-Allow-Origin', '*');

    constructor(private http: HttpClient) {}

    getQuestionnaires() {
        return this.http.get<any>(this.baseUrl).pipe(map((res: any) => {
            return res;
        }));    
    }

    createQuestionnaire(questionnaire: Questionnaire) {
        return this.http.post<any>(this.baseUrl, questionnaire).pipe(map((res: any) => {
            return res;
        }));
    }

    updateQuestionnaire(id: number, questionnaire: Questionnaire) {
        return this.http.put<any>(this.baseUrl + `/${id}`, questionnaire).pipe(map((res: any) => {
            return res;
        }));
    }

    deleteQuestionnaire(id: number) {
        return this.http.delete<any>(this.baseUrl + `/${id}`)
            .pipe(map((res: any) => {
                return res;
            }));
    }
}