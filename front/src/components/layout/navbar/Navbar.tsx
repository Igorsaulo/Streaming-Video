import { Padding } from "@mui/icons-material";
import {
    Box,
    Grid,
    IconButton,
    ListItemIcon,
    ListItemText,
    List,
    ListItem,
    MenuItem,
    Typography,
    Button,
    Tooltip,
    Avatar,
    Menu,
    Divider
} from "@mui/material";


import {
    PersonAdd as PersonAddIcon,
    Search as SearchIcon,
    Settings as SettingsIcon,
    Logout as LogoutIcon,
    NotificationsNone as NotificationsNoneIcon,
    VideoCall as VideoCallIcon,
} from "@mui/icons-material";
import React from "react";

const currencies = [
    {
        value: 'Português',
        label: 'Brasil',
    },
    {
        value: 'English',
        label: 'United States',
    },
    {
        value: 'Español',
        label: 'España',
    },
    {
        value: 'Français',
        label: 'France',
    },
    {
        value: 'Deutsch',
        label: 'Deutschland',
    },
    {
        value: 'Italiano',
        label: 'Italia',
    },
    {
        value: '日本語',
        label: '日本',
    },
    {
        value: '中文',
        label: '中国',
    },
];

const notfications = [
    {
        title: "Titulo",
        description: "Aconteceu alguma coisa, e eu não sei o que é",
        date: "01/01/2021"
    },
    {
        title: "Titulo",
        description: "Descrição",
        date: "01/01/2021"
    },
    {
        title: "Titulo",
        description: "Descrição",
        date: "01/01/2021"
    },
    {
        title: "Titulo",
        description: "Descrição",
        date: "01/01/2021"
    },
    {
        title: "Titulo",
        description: "Descrição",
        date: "01/01/2021"
    },
    {
        title: "Titulo",
        description: "Descrição",
        date: "01/01/2021"
    },
    {
        title: "Titulo",
        description: "Descrição",
        date: "01/01/2021"
    },
    {
        title: "Titulo",
        description: "Descrição",
        date: "01/01/2021"
    },
]

export function Navbar() {
    const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
    const [notficationAnchorEl, setNotficationAnchorEl] = React.useState<null | HTMLElement>(null);
    const openNotfication = Boolean(notficationAnchorEl);
    const open = Boolean(anchorEl);


    const handleClick = (event: React.MouseEvent<HTMLElement>) => {
        setAnchorEl(event.currentTarget);
    };

    const handleClose = () => {
        setAnchorEl(null);
    };

    const handleNotficationClick = (event: React.MouseEvent<HTMLElement>) => {
        setNotficationAnchorEl(event.currentTarget);
    }

    const handleNotficationClose = () => {
        setNotficationAnchorEl(null);
    }

    return (
        <Box
            position={"fixed"}
            top={0}
            left={0}
            width={"100vw"}
            height={"10vh"}
            bgcolor={"#fff"}
            padding={"0.5rem 0"}
        >
            <Grid
                container
                alignItems={"center"}
                height={"100%"}
            >
                <Grid
                    item
                    xs={4}
                    container
                    alignItems={"center"}
                    padding={"0 1rem"}

                >
                    <Grid
                        item
                        xs={1}
                        color={"black"}
                    >
                        Logo
                    </Grid>
                    <Grid
                        item
                        xs={4}
                        color={"black"}
                        justifyContent={"center"}
                    >
                        <Typography fontSize={"26px"} variant="h4">
                            Vide Cast
                        </Typography>
                    </Grid>
                    <Grid
                        item
                        xs={4}
                        color={"black"}
                        component={"form"}
                        justifyContent={"center"}>
                        <Typography>
                            Idioma: Portugues
                        </Typography>
                    </Grid>
                </Grid>
                <Grid
                    item
                    xs={4}
                    component={"form"}
                >
                    <Grid
                        item xs={10}
                        borderRadius={"0.5rem"}
                        bgcolor={"#3b3b3b"}>
                        <input type="text" placeholder="Buscar" name="search"
                            style={{
                                padding: "0.5rem",
                                borderRadius: "0.5rem",
                                backgroundColor: "#3b3b3b",
                                border: "none",
                                width: "70%",
                            }} />
                        <Button
                            sx={{
                                width: "25%",
                                borderTopRightRadius: "0.5rem",
                                borderBottomRightRadius: "0.5rem",
                                padding: "0.2rem",
                                border: "none",
                                bgcolor: "#3b3b3b",
                                color: "#fff",
                                "&:hover": {
                                    bgcolor: "#3b3b3b",
                                },
                                "&:focus": {
                                    bgcolor: "#3b3b3b",
                                    border: "none",
                                    outline: "none", // Remover a borda de foco
                                },
                            }}
                        >
                            <SearchIcon />
                        </Button>


                    </Grid>
                </Grid>
                <Grid
                    item
                    xs={4}
                >
                    <Grid
                        item
                        xs={12}
                        container
                        justifyContent={"flex-end"}
                    >
                        <Grid
                            item
                            xs={2}
                            color={"black"}
                        >
                            <Tooltip title="Notificações">
                                <IconButton
                                    aria-label="account of current user"
                                    aria-controls="menu-appbar"
                                    aria-haspopup="true"
                                    onClick={handleNotficationClick}
                                    color="inherit"
                                    sx={{
                                        "&:focus": {
                                            border: "none",
                                            outline: "none", // Remover a borda de foco
                                        },
                                    }}
                                >
                                    <NotificationsNoneIcon />
                                </IconButton>
                            </Tooltip>
                            <Menu
                                id="menu-appbar"
                                anchorEl={notficationAnchorEl}
                                anchorOrigin={{
                                    vertical: "top",
                                    horizontal: "right",
                                }}
                                keepMounted
                                transformOrigin={{
                                    vertical: "top",
                                    horizontal: "right",
                                }}
                                open={openNotfication}
                                onClose={handleNotficationClose}
                                sx={{
                                    top: "4rem",
                                }}
                            >
                                <List sx={{ width: 360, maxWidth: 360, bgcolor: 'background.paper' }}>
                                    {notfications.map((notfication) => (
                                        <ListItem alignItems="flex-start">
                                            <ListItemText
                                                primary={notfication.title}
                                                secondary={
                                                    <React.Fragment>
                                                        <Typography
                                                            sx={{ display: 'inline' }}
                                                            component="span"
                                                            variant="body2"
                                                            color="text.primary"
                                                        >
                                                            {notfication.description}
                                                        </Typography>
                                                        {` — ${notfication.date}`}
                                                    </React.Fragment>
                                                }
                                            />
                                        </ListItem>
                                    ))}
                                </List>
                            </Menu>

                        </Grid>
                        <Grid
                            item
                            xs={2}
                            color={"black"}
                            marginRight={"2rem"}
                        >
                            <Tooltip title="Configurações">
                                <IconButton
                                    aria-label="account of current user"
                                    aria-controls="menu-appbar"
                                    aria-haspopup="true"
                                    onClick={handleClick}
                                    color="inherit"
                                    sx={{
                                        "&:focus": {
                                            border: "none",
                                            outline: "none",
                                        },
                                    }}
                                >
                                    <Avatar sx={{ bgcolor: "#3b3b3b" }}>A</Avatar>
                                </IconButton>
                            </Tooltip>
                            <Menu
                                id="menu-appbar"
                                anchorEl={anchorEl}
                                anchorOrigin={{
                                    vertical: "top",
                                    horizontal: "right",
                                }}
                                keepMounted
                                transformOrigin={{
                                    vertical: "top",
                                    horizontal: "right",
                                }}
                                open={open}
                                onClose={handleClose}
                                sx={{
                                    top: "4rem",
                                }}
                            >
                                <MenuItem onClick={handleClose}>
                                    <ListItemIcon>
                                        <VideoCallIcon fontSize="small" />
                                    </ListItemIcon>
                                    <ListItemText>Adcionar video</ListItemText>
                                </MenuItem>
                                <MenuItem onClick={handleClose}>
                                    <ListItemIcon>
                                        <PersonAddIcon fontSize="small" />
                                    </ListItemIcon>
                                    <ListItemText>Adicionar conta</ListItemText>''
                                </MenuItem>
                                <MenuItem onClick={handleClose}>
                                    <ListItemIcon>
                                        <SettingsIcon fontSize="small" />
                                    </ListItemIcon>
                                    <ListItemText>Configurações</ListItemText>
                                </MenuItem>
                                <Divider />
                                <MenuItem onClick={handleClose}>
                                    <ListItemIcon>
                                        <LogoutIcon fontSize="small" />
                                    </ListItemIcon>
                                    <ListItemText>Sair</ListItemText>
                                </MenuItem>
                            </Menu>
                        </Grid>
                    </Grid>
                </Grid>
                {/* <Divider sx={{ width: "100%", bgcolor: "black" }} />
                <Grid
                    item
                    container
                    bgcolor={"#fff"}
                    xs={12}>
             
                    <Grid
                        item
                        xs={6}
                        borderBottom={"1px solid blue"}
                        justifyContent={"center"}>
                        <Typography >
                            Gravados
                        </Typography>
                    </Grid>
                    <Grid
                        item
                        xs={6}
                        justifyContent={"center"}>
                        <Typography color={"black"}>
                            Ao Vivo
                        </Typography>
                    </Grid>
                </Grid> */}
            </Grid>
        </Box>
    )
}