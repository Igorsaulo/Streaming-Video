import React, { useState } from 'react';
import { Avatar, Grid, Typography, createTheme } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import { Video } from '../../pages/home';

export function VideoCard({
  thumbnailUrl,
  logo,
  title,
  creatorName,
  videoUrl,
  videoId
}: Video) {
  const [isHovered, setIsHovered] = useState(false);
  const navigate = useNavigate();

  const handleMouseEnter = () => {
    setIsHovered(true);
  };

  const handleMouseLeave = () => {
    setIsHovered(false);
  };

  const handleClick = () => {
    navigate(`/play/${videoId}`);
  }

  return (
    <Grid
      bgcolor="#000"
      container
      item
      xs={2.8}
      onMouseEnter={handleMouseEnter}
      onMouseLeave={handleMouseLeave}
      onClick={handleClick}
      sx={{
        cursor: 'pointer',
      }}
    >
      <Grid width="100%" bgcolor="pink" height="25vh" item xs={12}>
        {isHovered ? (
          <video src={videoUrl} autoPlay loop muted style={{ width: '100%' }} />
        ) : (
          <img style={{ width: '100%' }} src={thumbnailUrl} alt="Thumbnail" />
        )}
      </Grid>
      <Grid width="100%" bgcolor="#fff" item xs={12} container>
        <Grid item xs={2}>
          <Avatar src={logo} />
        </Grid>
        <Grid item xs={10}>
          <Typography textAlign="left">{title}</Typography>
        </Grid>
        <Grid item paddingLeft="3rem" xs={12}>
          <Typography fontSize="14px" textAlign="left">
            {creatorName}
          </Typography>
        </Grid>
      </Grid>
    </Grid>
  );
}
