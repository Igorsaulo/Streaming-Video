import React from 'react'
import ReactDOM from 'react-dom/client'
import { Router } from './routes'
import './index.css'
import { Navbar } from './components/layout/navbar/Navbar'

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <Navbar />
    <Router />
  </React.StrictMode>,
)
