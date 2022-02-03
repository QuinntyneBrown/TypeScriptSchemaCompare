/* tslint:disable */
import { TypeScriptModelDto } from './type-script-model-dto';
export interface GetTypeScriptModelsPageResponse {
  entities?: Array<TypeScriptModelDto>;
  length?: number;
  validationErrors?: Array<string>;
}
