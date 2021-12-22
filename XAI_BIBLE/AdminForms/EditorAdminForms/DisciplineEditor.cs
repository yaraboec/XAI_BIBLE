﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.Context;
using DataAccess.Repositories;
using Services.Contracts;
using Services.Services;

namespace XAI_BIBLE.AdminForms.EditorAdminForms
{
    public partial class DisciplineEditor : Form
    {
        XaiBibleContext _context;
        ISqlRepository<DataAccess.Entities.Discipline> _repository;
        IDisciplineService _service;
        private Discipline _parenForm;
        private DataAccess.Entities.Discipline _discipline;

        public DisciplineEditor()
        {
            InitializeComponent();
            _context = new XaiBibleContext();
            _repository = new SqlRepository<DataAccess.Entities.Discipline>(_context);
            _service = new DisciplineService(_repository);
        }

        public void getGuidForUpdate(Guid id, Discipline parentForm)
        {
            var entity = _service.GetById(id);
            _discipline = entity;
            _parenForm = parentForm;

            textBoxInputNameDisc.Text = entity.Name;

            parentForm.Hide();
        }

        public void startEditorForAdd(Discipline parentForm)
        {
            _parenForm = parentForm;
            parentForm.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxInputNameDisc.Text != "")
            {
                if (_discipline == null)
                {
                    _service.Create(new DataAccess.Entities.Discipline()
                    {
                        Name = textBoxInputNameDisc.Text
                    });
                }
                else
                {
                    _discipline.Name = textBoxInputNameDisc.Text;

                    _service.Update(_discipline);
                }

                _parenForm.UpdateDataInGrid();
                _parenForm.Show();
                this.Close();
            }
        }
    }
}