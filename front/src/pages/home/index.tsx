import './Home.css'
import { Box, Grid, Typography, Avatar } from '@mui/material'
import { VideoCard } from '../../components/home/VideoCard'
import { useState, useEffect } from 'react'
import React from 'react'

export interface Video {
  thumbnailUrl: string;
  logo: string;
  title: string;
  creatorName: string;
  videoUrl: string;
  videoId: string;
}

function Home() {
  const [videos, setVideos] = useState<Video[]>([]);

  useEffect(() => {
    fetch('http://localhost:5071/api/video/page/0')
      .then(response => response.json())
      .then(data => {
        // Adicione as URLs das miniaturas aos objetos de vídeo
        const videosWithThumbnails: Video[] = data.map((video: any) => ({
          ...video,
          thumbnailUrl: `http://localhost:5071/api/video/thumbnail/${video.videoId}`,
          videoUrl: `http://localhost:5071/api/video/play/${video.videoId}`
        }));

        // Defina o estado com a lista de vídeos atualizada
        setVideos(videosWithThumbnails);
      });
  }, []);

  return (
    <Box
      marginTop={"20vh"}
      width={"100%"}
      justifyContent={"center"}
      display={"flex"}
    >
      <Grid
        container
        gap={2}
        xs={12}
      >
        {videos.map((video) => (
          <VideoCard
            thumbnailUrl={video.thumbnailUrl}
            logo={video.logo}
            title={video.title}
            creatorName={video.creatorName}
            videoUrl={video.videoUrl}
            videoId={video.videoId}
          />
        ))}
      </Grid>
    </Box>
  );
}

export { Home }
