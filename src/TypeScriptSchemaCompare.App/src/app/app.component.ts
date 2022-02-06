import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TypeScriptModelService } from '@api';
import { map, startWith, Subject, switchMap } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  
  readonly sourceControl = new FormControl();
  
  readonly compareToControl = new FormControl();
  
  private readonly _compareSubject: Subject<void> = new Subject();

  readonly vm$ = this._compareSubject.pipe(
    switchMap(_ => this._typeScriptModelService.compare({
      source: this.sourceControl.value,
      compareTo:this.compareToControl.value
    }).pipe(
      map(response => ({ errors: response.errors }))
    )),
    startWith({ errors: null }),
  );

  constructor(
    private readonly _typeScriptModelService: TypeScriptModelService
  ) { }

  compare() {
    this._compareSubject.next();
  }
}
