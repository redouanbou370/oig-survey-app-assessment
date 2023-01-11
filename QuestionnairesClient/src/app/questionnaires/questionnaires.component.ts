import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Questionnaire } from '../models/Questionnaire';
import { Status } from '../models/Status';
import { QuestionnaireService } from '../services/questionnaires.service';

@Component({
  selector: 'app-questionnaires',
  templateUrl: './questionnaires.component.html',
  styleUrls: ['./questionnaires.component.css']
})
export class QuestionnairesComponent {

  questionnaireModel = new Questionnaire;
  allQuestions: any;

  showAdd!: boolean;
  showUpdate!: boolean;

  formValue!: FormGroup;

  allStatus = [
    new Status(1, 'Contept'),
    new Status(2, 'Scheduled'),
    new Status(3, 'Active'),
    new Status(4, 'Finished')
  ] 

  constructor(private formBuilder: FormBuilder, private _service: QuestionnaireService) { }

  ngOnInit(): void {
    this.formValue = this.formBuilder.group({
      name: ['', Validators.required],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      statusId: ['', Validators.required]
    });

    this.getQuestionnaires();
  }

  add() {
    this.showAdd = true;
    this.showUpdate = false;
  }

  edit(data: any) {
    this.showAdd = false;
    this.showUpdate = true;

    this.questionnaireModel.Id = data.id;

    this.formValue.controls['Name'].setValue(data.name);
    this.formValue.controls['StartDate'].setValue(data.startDate);
    this.formValue.controls['EndDate'].setValue(data.endDate);
    this.formValue.controls['StatusId'].setValue(data.status);
  }

  getQuestionnaires() {
    this._service.getQuestionnaires()
      .subscribe(data => {
        this.allQuestions = data;
        console.log(this.allQuestions);
      });
  }

  addQuestionnaire() {
    console.log(this.formValue.value.status);
    this.questionnaireModel.Name = this.formValue.value.name;
    this.questionnaireModel.StartDate = this.formValue.value.startDate;
    this.questionnaireModel.EndDate = this.formValue.value.endDate;
    this.questionnaireModel.StatusId = parseInt(this.formValue.value.status, 10);

    this._service.createQuestionnaire(this.questionnaireModel)
      .subscribe(res => {
        this.formValue.reset();
        this.getQuestionnaires();
        alert("Record successfully created.")
      }, error => {
        console.log(error.message);
        alert("Something went wrong!");
      });
  }

  updateQuestionnaire() {
    this.questionnaireModel.Name = this.formValue.value.name;
    this.questionnaireModel.StartDate = this.formValue.value.startDate;
    this.questionnaireModel.EndDate = this.formValue.value.endDate;
    this.questionnaireModel.StatusId = this.formValue.value.status;

    this._service.updateQuestionnaire(this.questionnaireModel.Id, this.questionnaireModel)
      .subscribe(res => {
        this.formValue.reset();

        this.getQuestionnaires();
        alert("Record succesfully added.")
      }, error => {
        console.log(error.message);
        alert("Something went wrong...")
      });
  }

  deleteRecord(id: number) {
    if (confirm("Are you sure to delete the selected Questionnaire?")) {
      this._service.deleteQuestionnaire(id)
        .subscribe(res => {
          this.getQuestionnaires();
          alert("Record succesvol verwijderd.")
        }, error => {
          console.log(error);
        });
    }
  }

}
