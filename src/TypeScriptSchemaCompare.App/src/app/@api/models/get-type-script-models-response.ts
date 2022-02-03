/* tslint:disable */
import { TypeScriptModelDto } from './type-script-model-dto';
export interface GetTypeScriptModelsResponse {
  typeScriptModels?: Array<TypeScriptModelDto>;
  validationErrors?: Array<string>;
}
