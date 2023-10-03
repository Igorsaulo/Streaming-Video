import { Grid, Typography } from "@mui/material";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Video } from "../../pages/home";


export function Thumbnail({
    thumbnailUrl, title, creatorName, logo, videoUrl, videoId }
    : Video) {
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
        window.location.reload();
    }
    return (
        <Grid padding={1} gap={0.5} container item xs={12}>
            <Grid
                bgcolor="#000"
                container
                item
                xs={5.7}
                onMouseEnter={handleMouseEnter}
                onMouseLeave={handleMouseLeave}
                onClick={handleClick}
                sx={{
                    cursor: 'pointer',
                }}
            >
                <Grid width="100%" bgcolor="pink" height="16vh" item xs={12}>
                    {isHovered ? (
                        <video src={videoUrl} autoPlay loop muted style={{ width: '100%' }} />
                    ) : (
                        <img style={{ width: '100%' }} src={thumbnailUrl} alt="Thumbnail" />
                    )}
                </Grid>
            </Grid>
            <Grid width={"100%"} bgcolor={"#fff"} item xs={6.3} container>
                <Grid item xs={12}>
                    <Typography textAlign="left">{title}</Typography>
                </Grid>
                <Grid item xs={12}>
                    <Typography fontSize={"14px"} textAlign="left">
                        {creatorName}
                    </Typography>
                </Grid>
            </Grid>
        </Grid>
    )
}