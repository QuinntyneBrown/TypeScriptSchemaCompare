/* tslint:disable */
import { TypeScriptModelDto } from './type-script-model-dto';
export interface GetTypeScriptModelByIdResponse {
  typeScriptModel?: TypeScriptModelDto;
  validationErrors?: Array<string>;
}
