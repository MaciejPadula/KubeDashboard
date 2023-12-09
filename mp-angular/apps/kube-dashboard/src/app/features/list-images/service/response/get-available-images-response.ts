import { DockerImage } from "../../model/docker-image";

export interface GetAvailableImages {
  images: DockerImage[];
}
