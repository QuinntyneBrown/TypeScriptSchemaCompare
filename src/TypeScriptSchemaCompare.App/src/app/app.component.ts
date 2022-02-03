import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TypeScriptModelService } from '@api';
import { tap } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  sourceControl = new FormControl();
  compareToControl = new FormControl();
  errors: string[];

  constructor(
    private readonly _typeScriptModelService: TypeScriptModelService
  ) {

  }

  compare() {
    this._typeScriptModelService.compare({
      source: this.sourceControl.value,
      compareTo:this.compareToControl.value
    }).pipe(
      tap(response => this.errors = response.errors)
    ).subscribe();
  }
}
