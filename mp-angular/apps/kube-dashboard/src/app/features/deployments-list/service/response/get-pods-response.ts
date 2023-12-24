import { Pod } from "../../../../shared/model/pod";

export interface GetDeploymentPodsResponse {
  alivePods: Pod[];
  deadPods: Pod[];
}