import { Box, Grid, Typography, Avatar, Button, List, ListItem, ListItemButton, ListItemIcon, ListItemText } from "@mui/material";
import {
  ThumbUp as ThumbUpIcon,
  ThumbDown as ThumbDownIcon,
} from "@mui/icons-material";
import { Thumbnail } from "../../components/play/thumbnail";
import { Video } from "../home";
import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";

const VideoInfo = [
  {
    thumbnail: "https://i.ytimg.com/vi/rapH3oDi-sY/maxresdefault.jpg",
    title: "Novo apple plus",
    criador: "Apple In.",
    views: 22,
    tempo: "10 anos"
  },
  {
    thumbnail: "https://i.ytimg.com/vi/rapH3oDi-sY/maxresdefault.jpg",
    title: "Novo apple plus",
    criador: "Apple In.",
    views: 22,
    tempo: "10 anos"
  },
  {
    thumbnail: "https://i.ytimg.com/vi/rapH3oDi-sY/maxresdefault.jpg",
    title: "Novo apple plus",
    criador: "Apple In.",
    views: 22,
    tempo: "10 anos"
  },
  {
    thumbnail: "https://i.ytimg.com/vi/rapH3oDi-sY/maxresdefault.jpg",
    title: "Novo apple plus",
    criador: "Apple In.",
    views: 22,
    tempo: "10 anos"
  },
  {
    thumbnail: "https://i.ytimg.com/vi/rapH3oDi-sY/maxresdefault.jpg",
    title: "Novo apple plus",
    criador: "Apple In.",
    views: 22,
    tempo: "10 anos"
  },
  {
    thumbnail: "https://i.ytimg.com/vi/rapH3oDi-sY/maxresdefault.jpg",
    title: "Novo apple plus",
    criador: "Apple In.",
    views: 22,
    tempo: "10 anos"
  },
  {
    thumbnail: "https://i.ytimg.com/vi/rapH3oDi-sY/maxresdefault.jpg",
    title: "Novo apple plus",
    criador: "Apple In.",
    views: 22,
    tempo: "10 anos"
  }
]


export function Play() {
  const { id } = useParams<{ id: string }>();
  const [videos, setVideos] = useState<Video[]>([]);

  useEffect(() => {
    fetch('http://localhost:5071/api/video/page/0')
      .then(response => response.json())
      .then(data => {
        // Adicione as URLs das miniaturas e URLs de vídeo aos objetos de vídeo
        const videosWithThumbnailsAndVideoUrls: Video[] = data.map((video: any) => ({
          ...video,
          thumbnailUrl: `http://localhost:5071/api/video/thumbnail/${video.videoId}`,
          videoUrl: `http://localhost:5071/api/video/play/${video.videoId}`
        }));

        // Filtrar os vídeos para excluir aqueles em que o videoId seja igual ao userId
        const filteredVideos = videosWithThumbnailsAndVideoUrls.filter((video: Video) => video.videoId !== id);

        setVideos(filteredVideos);
      });
  }, []);


  return (
    <Box
      sx={{
        width: "100%",
        height: "100vh",
        color: "#fff",
        marginTop: "4rem",
      }}>
      <Grid
        gap={2}
        xs={12}
        padding={2}
        container>
        <Grid
          item
          container
          xs={7.9}>
          <Grid
            item
            height={"70vh"}
            color={"#000"}
            xs={12}>

            <video controls width="640" height="360">
              <source src={`http://localhost:5071/api/video/play/${id}`} type="video/mp4">
              </source>
            </video>
          </Grid>
          <Grid
            item
            xs={12}
            color={"#000"}>
            <Typography
              marginTop={2}
              fontSize={"20px"}
              textAlign="left"
            >
              Titulo do video
            </Typography>
          </Grid>
          <Grid
            item
            color={"black"}

            container
            xs={12}>
            <Grid
              item
              xs={0.7}>
              <Avatar
                src={"https://yt3.ggpht.com/ytc/AKedOLQJXw6u3JXJ5k6j6l4U6kqXqJXnYRdYgY5XW7lQ=s176-c-k-c0x00ffffff-no-rj"}
              />
            </Grid>
            <Grid
              item
              xs={2.5}>
              <Typography
                fontSize={"16px"}
                textAlign="left"
              >
                Junior
              </Typography>
              <Typography
                textAlign="left"
                fontSize={"14px"}
              >
                1.000.000 de views
              </Typography>
            </Grid>
            <Grid
              item
              alignItems={"start"}
              display={"flex"}
              xs={3}>
              <Button
                variant="contained"
                color="secondary"
                sx={{ borderRadius: "20px" }}
              >
                Inscrever-se
              </Button>
            </Grid>
            <Grid
              item
              bgcolor={"#9C27B0"}
              display={"flex"}
              alignItems={"center"}
              padding={0}
              margin={0}
              borderRadius={"20px"}
              justifyContent={"space-around"}

              xs={2.4}>
              <Grid
                item
                color={"#fff"}
                display={"flex"}
                alignItems={"center"}
              >
                <ThumbUpIcon />
                <Typography
                  fontSize={"14px"}
                  textAlign="left"
                  sx={{ marginLeft: "5px" }}
                >
                  1 Mil
                </Typography>
              </Grid>
              <Grid
                item
                color={"#fff"}
                display={"flex"}
                alignItems={"center"}>
                <ThumbDownIcon />
              </Grid>
            </Grid>
          </Grid>
          <Grid
            item
            xs={12}
            color={"#000"}>
            <Typography
              marginTop={2}
              fontSize={"14px"}
              textAlign="left"
            >
              259.558 visualizações  Estreou em 1 de mar. de 2023  #IniciativaEditores
              A iniciativa editores é um projeto que reúne alguns dos maiores nomes da comunidade de edit brasileira, afim de unir suas comunidades e dar oportunidade para editores pequenos crescerem.

              Nenhuma das imagens e áudios utilizados pertencem ao canal Iniciativa Editores. Esta é uma edição motivacional, todas o material usado pertence aos detentores legais dos filmes, jogos, séries e animações usadas no vídeo.

              Editores deste vídeo/ Imagens usadas:

              00:00 Interativo Edições
              ( @Interativoedicoes )
              Vikings, Sons of Anarchy, Peaky Blinders, Detroit Become Human, Blade Runner 2099, Round 6, Braking Bad, 300, Finch, GTA V, Hellblade, O Homem de Aço, Brightburn, Falcão e o Soldado Invernal, Red Dead Redemption 2, Espartacus
            </Typography>
          </Grid>
          <Grid
            item
            xs={12}
            color={"#000"}>
            <Typography
              marginTop={2}
              fontSize={"20px"}
              textAlign="left"
            >
              Comentários
            </Typography>
          </Grid>
          <Grid
            item
            xs={12}
            container
            paddingTop={2}
            gap={2}
            color={"#000"}>
            <Grid
              item
              xs={0.7}>
              <Avatar
                src={"https://yt3.ggpht.com/ytc/AKedOLQJXw6u3JXJ5k6j6l4U6kqXqJXnYRdYgY5XW7lQ=s176-c-k-c0x00ffffff-no-rj"}
              />
            </Grid>
            <Grid
              item
              display={"flex"}
              alignItems={"center"}
              xs={11}>
              <input
                style={{
                  width: "100%",
                  border: "none",
                  borderBottom: "1px solid #000",
                  outline: "none", // Remova a borda de foco padrão
                }}
                type="text"
              />
            </Grid>
          </Grid>

        </Grid>
        <Grid color={"black"} item xs={3.9}>
          {videos.map((video) => (
            <Thumbnail
              thumbnailUrl={video.thumbnailUrl}
              logo={video.logo}
              title={video.title}
              creatorName={video.creatorName}
              videoUrl={video.videoUrl}
              videoId={video.videoId}
            />
          ))}
        </Grid>
      </Grid>
    </Box>
  )
}