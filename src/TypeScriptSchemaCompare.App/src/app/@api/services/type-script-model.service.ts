/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { GetTypeScriptModelByIdResponse } from '../models/get-type-script-model-by-id-response';
import { RemoveTypeScriptModelResponse } from '../models/remove-type-script-model-response';
import { GetTypeScriptModelsResponse } from '../models/get-type-script-models-response';
import { CreateTypeScriptModelResponse } from '../models/create-type-script-model-response';
import { CreateTypeScriptModelRequest } from '../models/create-type-script-model-request';
import { UpdateTypeScriptModelResponse } from '../models/update-type-script-model-response';
import { UpdateTypeScriptModelRequest } from '../models/update-type-script-model-request';
import { CompareResponse } from '../models/compare-response';
import { CompareRequest } from '../models/compare-request';
import { GetTypeScriptModelsPageResponse } from '../models/get-type-script-models-page-response';
@Injectable({
  providedIn: 'root',
})
class TypeScriptModelService extends __BaseService {
  static readonly getTypeScriptModelByIdPath = '/api/TypeScriptModel/{typeScriptModelId}';
  static readonly removeTypeScriptModelPath = '/api/TypeScriptModel/{typeScriptModelId}';
  static readonly getTypeScriptModelsPath = '/api/TypeScriptModel';
  static readonly createTypeScriptModelPath = '/api/TypeScriptModel';
  static readonly updateTypeScriptModelPath = '/api/TypeScriptModel';
  static readonly comparePath = '/api/TypeScriptModel/compare';
  static readonly getTypeScriptModelsPagePath = '/api/TypeScriptModel/page/{pageSize}/{index}';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Get TypeScriptModel by id.
   *
   * Get TypeScriptModel by id.
   * @param typeScriptModelId undefined
   * @return Success
   */
  getTypeScriptModelByIdResponse(typeScriptModelId: string): __Observable<__StrictHttpResponse<GetTypeScriptModelByIdResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/TypeScriptModel/${encodeURIComponent(String(typeScriptModelId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetTypeScriptModelByIdResponse>;
      })
    );
  }
  /**
   * Get TypeScriptModel by id.
   *
   * Get TypeScriptModel by id.
   * @param typeScriptModelId undefined
   * @return Success
   */
  getTypeScriptModelById(typeScriptModelId: string): __Observable<GetTypeScriptModelByIdResponse> {
    return this.getTypeScriptModelByIdResponse(typeScriptModelId).pipe(
      __map(_r => _r.body as GetTypeScriptModelByIdResponse)
    );
  }

  /**
   * Delete TypeScriptModel.
   *
   * Delete TypeScriptModel.
   * @param typeScriptModelId undefined
   * @return Success
   */
  removeTypeScriptModelResponse(typeScriptModelId: string): __Observable<__StrictHttpResponse<RemoveTypeScriptModelResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/TypeScriptModel/${encodeURIComponent(String(typeScriptModelId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<RemoveTypeScriptModelResponse>;
      })
    );
  }
  /**
   * Delete TypeScriptModel.
   *
   * Delete TypeScriptModel.
   * @param typeScriptModelId undefined
   * @return Success
   */
  removeTypeScriptModel(typeScriptModelId: string): __Observable<RemoveTypeScriptModelResponse> {
    return this.removeTypeScriptModelResponse(typeScriptModelId).pipe(
      __map(_r => _r.body as RemoveTypeScriptModelResponse)
    );
  }

  /**
   * Get TypeScriptModels.
   *
   * Get TypeScriptModels.
   * @return Success
   */
  getTypeScriptModelsResponse(): __Observable<__StrictHttpResponse<GetTypeScriptModelsResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/TypeScriptModel`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetTypeScriptModelsResponse>;
      })
    );
  }
  /**
   * Get TypeScriptModels.
   *
   * Get TypeScriptModels.
   * @return Success
   */
  getTypeScriptModels(): __Observable<GetTypeScriptModelsResponse> {
    return this.getTypeScriptModelsResponse().pipe(
      __map(_r => _r.body as GetTypeScriptModelsResponse)
    );
  }

  /**
   * Create TypeScriptModel.
   *
   * Create TypeScriptModel.
   * @param body undefined
   * @return Success
   */
  createTypeScriptModelResponse(body?: CreateTypeScriptModelRequest): __Observable<__StrictHttpResponse<CreateTypeScriptModelResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/TypeScriptModel`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<CreateTypeScriptModelResponse>;
      })
    );
  }
  /**
   * Create TypeScriptModel.
   *
   * Create TypeScriptModel.
   * @param body undefined
   * @return Success
   */
  createTypeScriptModel(body?: CreateTypeScriptModelRequest): __Observable<CreateTypeScriptModelResponse> {
    return this.createTypeScriptModelResponse(body).pipe(
      __map(_r => _r.body as CreateTypeScriptModelResponse)
    );
  }

  /**
   * Update TypeScriptModel.
   *
   * Update TypeScriptModel.
   * @param body undefined
   * @return Success
   */
  updateTypeScriptModelResponse(body?: UpdateTypeScriptModelRequest): __Observable<__StrictHttpResponse<UpdateTypeScriptModelResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/TypeScriptModel`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<UpdateTypeScriptModelResponse>;
      })
    );
  }
  /**
   * Update TypeScriptModel.
   *
   * Update TypeScriptModel.
   * @param body undefined
   * @return Success
   */
  updateTypeScriptModel(body?: UpdateTypeScriptModelRequest): __Observable<UpdateTypeScriptModelResponse> {
    return this.updateTypeScriptModelResponse(body).pipe(
      __map(_r => _r.body as UpdateTypeScriptModelResponse)
    );
  }

  /**
   * Compare TypeScriptModels
   *
   * Compare TypeScriptModels
   * @param body undefined
   * @return Success
   */
  compareResponse(body?: CompareRequest): __Observable<__StrictHttpResponse<CompareResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/TypeScriptModel/compare`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<CompareResponse>;
      })
    );
  }
  /**
   * Compare TypeScriptModels
   *
   * Compare TypeScriptModels
   * @param body undefined
   * @return Success
   */
  compare(body?: CompareRequest): __Observable<CompareResponse> {
    return this.compareResponse(body).pipe(
      __map(_r => _r.body as CompareResponse)
    );
  }

  /**
   * Get TypeScriptModel Page.
   *
   * Get TypeScriptModel Page.
   * @param params The `TypeScriptModelService.GetTypeScriptModelsPageParams` containing the following parameters:
   *
   * - `pageSize`:
   *
   * - `index`:
   *
   * @return Success
   */
  getTypeScriptModelsPageResponse(params: TypeScriptModelService.GetTypeScriptModelsPageParams): __Observable<__StrictHttpResponse<GetTypeScriptModelsPageResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;


    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/TypeScriptModel/page/${encodeURIComponent(String(params.pageSize))}/${encodeURIComponent(String(params.index))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetTypeScriptModelsPageResponse>;
      })
    );
  }
  /**
   * Get TypeScriptModel Page.
   *
   * Get TypeScriptModel Page.
   * @param params The `TypeScriptModelService.GetTypeScriptModelsPageParams` containing the following parameters:
   *
   * - `pageSize`:
   *
   * - `index`:
   *
   * @return Success
   */
  getTypeScriptModelsPage(params: TypeScriptModelService.GetTypeScriptModelsPageParams): __Observable<GetTypeScriptModelsPageResponse> {
    return this.getTypeScriptModelsPageResponse(params).pipe(
      __map(_r => _r.body as GetTypeScriptModelsPageResponse)
    );
  }
}

module TypeScriptModelService {

  /**
   * Parameters for getTypeScriptModelsPage
   */
  export interface GetTypeScriptModelsPageParams {
    pageSize: number;
    index: number;
  }
}

export { TypeScriptModelService }
